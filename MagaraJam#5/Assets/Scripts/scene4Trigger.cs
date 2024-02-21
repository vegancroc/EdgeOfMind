using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scene4Trigger : MonoBehaviour
{
    [SerializeField]
    private Transform camFollow;

    [SerializeField]
    private GameObject text;

    private CinemachineVirtualCamera cam;

    private Player playerScript;

    private Rigidbody2D rb;

    private void Start()
    {
        cam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        playerScript = GameObject.Find("PlayerParent").GetComponent<Player>();
        rb = GameObject.Find("PlayerParent").GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.SetActive(true);
            rb.velocity = Vector3.zero;
            Variables.moveable = false;
            cam.Follow = camFollow;
            playerScript.enabled = false;
        }
    }
}
