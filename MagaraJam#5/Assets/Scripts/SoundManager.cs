using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip wordEffect;

    [SerializeField]
    private AudioClip fallEffect;

    [SerializeField]
    private AudioClip glassBreakEffect;

    [SerializeField]
    private AudioClip cardPickEffect;

    [SerializeField]
    private AudioClip doorOpenEffect;

    [SerializeField]
    private AudioClip laserShotEffect;

    [SerializeField]
    private AudioClip enemyDeathEffect;

    [SerializeField]
    private AudioClip enemyShotEffect;

    [SerializeField]
    private AudioClip alertEffect;

    [SerializeField]
    private AudioClip explosionEffect;

    [SerializeField]
    private AudioClip playerDeathEffect;

    public static SoundManager Instance;
     
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    public void playWordEffect()
    {
        audioSource.PlayOneShot(wordEffect,0.05f);
    }

    public void playFallDownEffect()
    {
        audioSource.PlayOneShot(fallEffect, 0.15f);
    }

    public void playGlassBreak()
    {
        audioSource.PlayOneShot(glassBreakEffect, 0.05f);
    }

    public void playCardPick()
    {
        audioSource.PlayOneShot(cardPickEffect,0.1f);
    }

    public void PlayDoorOpen()
    {
        audioSource.PlayOneShot(doorOpenEffect,0.1f);
    }

    public void PlayLaserShootEffect()
    {
        audioSource.PlayOneShot(laserShotEffect,0.1f);
    }

    public void PlayEnemyDeathEffect()
    {
        audioSource.PlayOneShot(enemyDeathEffect, 0.5f);
    }

    public void PlayEnemyShotEffect()
    {
        audioSource.PlayOneShot(enemyShotEffect,.1f);
    }

    public void PlayAlertEffect()
    {
        audioSource.PlayOneShot(alertEffect,.1f);
    }

    public void PlayExplosionEffect()
    {
        audioSource.PlayOneShot(explosionEffect,.1f);
    }

    public void PlayPlayerDeathEffect()
    {
        audioSource.PlayOneShot(playerDeathEffect, .1f);
    }
}


