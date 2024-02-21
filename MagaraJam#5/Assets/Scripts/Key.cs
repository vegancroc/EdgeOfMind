using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
public class Key : MonoBehaviour
{
    [System.NonSerialized]
    public int killCount;

    [System.NonSerialized]
    public bool isKeyPickedUp = false;

    private SpriteRenderer sr;

    private Image cardImage;

    private BoxCollider2D collider;

    [SerializeField] private GameObject headLight;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        cardImage = GameObject.Find("card").GetComponent<Image>();
        collider = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.playCardPick();
            collider.enabled = false;
            isKeyPickedUp = true;
            sr.enabled = false;
            cardImage.enabled = true;

            headLight.GetComponent<SpriteRenderer>().color = Color.green;
            headLight.GetComponent<Light2D>().color = Color.green;
        }
    }

    public void AddKillCount()
    {
        killCount++;
    }

    public int getKillCount()
    {
        return killCount;
    }

    public void setPickedUp(bool setBool)
    {
        isKeyPickedUp = setBool;
    }

    public bool getIsKeyPickedUp()
    {
        return isKeyPickedUp;
    }
}
