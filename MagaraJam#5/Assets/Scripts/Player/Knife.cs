using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private Key key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {   
                key.AddKillCount();
                Debug.Log(key.getKillCount());
                SoundManager.Instance.PlayEnemyDeathEffect();
                EnemyDeathEvents(collision); 
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
        sr.enabled = true;
        enemy.enabled = false;
        anim.SetTrigger("Splash");
        Destroy(collision.transform.parent.gameObject, 4);
    }
}
