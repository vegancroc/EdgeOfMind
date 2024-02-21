using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    private float afterStartFadeTime;

    private bool fadePass = false;

    private Image image;
    private void Start()
    {
        image = this.GetComponent<Image>();
        Invoke("startFading", afterStartFadeTime);
        Invoke("loadOtherScene", afterStartFadeTime + 7);
    }

    private void FixedUpdate()
    {
        if (fadePass)
        {
            image.color += new Color(0, 0, 0, .005f);
        }
    }

    private void startFading()
    {
        fadePass = true;
    }
    private void loadOtherScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
