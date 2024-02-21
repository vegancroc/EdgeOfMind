using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ProfessorScene : MonoBehaviour
{
    [SerializeField]
    private Image black;

    [SerializeField]
    private Image white;

    [SerializeField]
    private GameObject AnnaText;

    [SerializeField]
    private GameObject ProfessorText;

    bool whitePass = false;

    private void Start()
    {
        StartCoroutine(PlayTexts());
    }
    private void FixedUpdate()
    {
        black.color -= new Color(0, 0, 0, .01f);

        if (whitePass)
        {
            white.color += new Color(0, 0, 0, .1f);
        }
    }

    private IEnumerator PlayTexts()
    {
        yield return new WaitForSeconds(1);
        AnnaText.SetActive(true);
        yield return new WaitForSeconds(50);
        ProfessorText.SetActive(true);
        yield return new WaitForSeconds(20);
        whitePass = true;
        SoundManager.Instance.PlayExplosionEffect();
        yield return new WaitForSeconds(.5f);
        SoundManager.Instance.PlayExplosionEffect();
        yield return new WaitForSeconds(.5f);
        SoundManager.Instance.PlayExplosionEffect();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  
}
