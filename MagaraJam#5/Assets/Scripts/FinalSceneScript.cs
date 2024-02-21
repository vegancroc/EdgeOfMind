using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalSceneScript : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float startTextTime;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private GameObject text2;

    [SerializeField]
    private Transform camDestination;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource sadMusic;

    [SerializeField]
    private GameObject white;

    [SerializeField]
    private GameObject Credits;

    [SerializeField]
    private GameObject redText;

    private Animator anim;

    private bool cameraMove = true;

    private bool creditPass = false;
    private void Start()
    {
        anim = GameObject.Find("Anna").GetComponent<Animator>();
        cam = Camera.main;
        StartCoroutine(StartCutscene());
    }

    private void FixedUpdate()
    {
        if (cameraMove)
        { 
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(camDestination.position.x, cam.transform.position.y, cam.transform.position.z), 1.5f * Time.fixedDeltaTime);
        }

        if (creditPass)
        {
            Credits.transform.position += new Vector3(0, 1, 0);
        }
    }

    private IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(startTextTime);
        text.SetActive(true);
        yield return new WaitForSeconds(45);
        text2.SetActive(true);
        audioSource.Stop();
        sadMusic.Stop();
        yield return new WaitForSeconds(5);
        redText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        white.SetActive(true);
        SoundManager.Instance.PlayLaserShootEffect();
        yield return new WaitForSeconds(.3f);
        redText.gameObject.SetActive(false);
        white.SetActive(false);
        anim.SetTrigger("dead");
        yield return new WaitForSeconds(3);
        Credits.SetActive(true);
        yield return new WaitForSeconds(3);
        creditPass = true;
        sadMusic.Play();
        audioSource.Play();
    }

}
