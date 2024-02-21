using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserPower;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private GameObject laserBar;
    [SerializeField] private Key key;
    private TrailRenderer tr;
    
    private Rigidbody2D rb;

    private float lifeTimeTimer=3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    void FixedUpdate()
    { 
        lifeTimeTimer += Time.deltaTime;
    }
   
    public void setDirection(Vector2 direction)
    {
        if (lifeTimeTimer > 5.0)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.SetActive(true);
            transform.position = laserPoint.position;
            tr.Clear();
            SoundManager.Instance.PlayLaserShootEffect();
            laserBar.SetActive(false);
            lifeTimeTimer = 0;
            tr.enabled = true;
            rb.velocity = direction * laserPower * Time.fixedDeltaTime;
            laserBar.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            key.AddKillCount();
            Debug.Log(key.getKillCount());
            SoundManager.Instance.PlayEnemyDeathEffect();
            rb.velocity = Vector2.zero;
            GetComponent<SpriteRenderer>().enabled = false;
            EnemyDeathEvents(collision);
        }
        else if (!collision.CompareTag("Player")&& !collision.CompareTag("Bullet"))
        {
            
            rb.velocity = Vector2.zero;
            tr.Clear();
            GetComponent<SpriteRenderer>().enabled = false;
        }
        }

    private void EnemyDeathEvents(Collider2D collision)
    {

        Animator anim = collision.transform.parent.GetChild(2).GetComponent<Animator>();
        SpriteRenderer sr = collision.transform.parent.GetChild(2).GetComponent<SpriteRenderer>();
        Enemy enemy = collision.transform.parent.GetChild(1).GetComponent<Enemy>();
        collision.GetComponent<Animator>().SetTrigger("Death");
        collision.GetComponent<BoxCollider2D>().enabled = false;
        collision.GetComponent<Rigidbody2D>().gravityScale = 0;
        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        collision.GetComponent<Enemy>().enabled = false;
        sr.enabled = true;
        enemy.enabled = false;
        anim.SetTrigger("Splash");
        Destroy(collision.transform.parent.gameObject, 4);
    }
}
