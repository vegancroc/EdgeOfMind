using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class Projectile : MonoBehaviour
{

    [SerializeField] private float bulletSpeed;
    [SerializeField] private Animator anim;
    
   

    private float direction;

    private Rigidbody2D rb;

    private float lifeTimeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(bulletSpeed * Time.deltaTime * direction, 0);

        if (lifeTimeTimer >= 3f)
            DeActive();

        lifeTimeTimer += Time.deltaTime;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            Debug.Log("Playera vurdu");
            Variables.IsPlayerDead = true;
            Variables.moveable = false;
            SoundManager.Instance.PlayPlayerDeathEffect();
            
        }
    }

    public void setDirection(float  _direction)
    {
        SoundManager.Instance.PlayEnemyShotEffect();
        gameObject.SetActive(true);
        lifeTimeTimer = 0;
        direction = _direction;
        
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }

}

