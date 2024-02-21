using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform bulletPos;

    [SerializeField] private float followSpeed;
    [SerializeField] private float playerDistance;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float returnTime;

    private float shootTimer;
    private float scaleTimer;

    private Animator anim;
    private Rigidbody2D rb;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        if(IsPlayerNear()&&shootTimer>=1f && !Variables.IsPlayerDead)
        Shooting();

        if (IsPlayerNear() && !IsPlayerClose())
        {
            followPlayer();
        }

        shootTimer += Time.deltaTime;
        scaleTimer += Time.deltaTime;

        if (!IsPlayerNear()&&scaleTimer >returnTime)
        {
            scaleTimer = 0;
           transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }

        if (IsPlayerNear())
            scaleTimer = 0;
        

        anim.SetBool("Walking", Mathf.Abs(rb.velocity.x) > 0.1f ? true : false);
    }  

    private void followPlayer()
    {
      
        rb.velocity = new Vector2(Mathf.Sign(transform.localScale.x)*followSpeed*Time.deltaTime, rb.velocity.y);
        
    }

    private bool IsPlayerNear()
    {
        if (Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), playerDistance, playerLayer))
            return true;
        else
            return false;

    }

    private bool IsPlayerClose()
    {
        if (Physics2D.Raycast(transform.position, new Vector2(transform.localScale.x, 0), playerDistance/2, playerLayer))
            return true;
        else
            return false;

    }

    private void Shooting()
    {
        anim.SetTrigger("Shoot");
        shootTimer = 0;
        bullets[RightBullet()].transform.position = bulletPos.position;
        bullets[RightBullet()].GetComponent<Projectile>().setDirection(Mathf.Sign(transform.localScale.x));
 
    }

    private int RightBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }
        return 80;

    }
}

