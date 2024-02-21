using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene7Script : MonoBehaviour
{
    [SerializeField]
    private Image black;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private float FadeTime;

    private bool blackPass = false;

    private void Start()
    {
        StartCoroutine(setTextAndNextScene());
    }

    private void FixedUpdate()
    {
        if (blackPass)
        {
            black.color += new Color(0, 0, 0, .01f);
        }
    }

    private IEnumerator setTextAndNextScene()
    {
        yield return new WaitForSeconds(2);
        text.SetActive(true);
        yield return new WaitForSeconds(FadeTime);
        blackPass = true;
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
