using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathAnim : MonoBehaviour
{
    [SerializeField]
    private Laser laser;

    private Camera cam;

    [SerializeField]
    private float flashTimeDuration;

    [SerializeField]
    private float StartSceneAgainTime;

    [SerializeField]
    private SpriteRenderer sr;

    
    private void Start()
    {
        cam = Camera.main;
       
    }

    private void Update()
    {
        if (Variables.IsPlayerDead)
        {
            StartCoroutine(FlashEffect());
        }

    }

    private IEnumerator FlashEffect()
    {
        Variables.moveable = false;
        cam.cullingMask = LayerMask.GetMask("Player", "white");
        sr.enabled = true;
        yield return new WaitForSeconds(flashTimeDuration);
        sr.color = Color.black;
        yield return new WaitForSeconds(StartSceneAgainTime);
        Variables.IsPlayerDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



}
