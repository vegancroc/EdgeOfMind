using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class scene4Dialogue : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string[] texts;

    private TextMeshPro textMesh;

    [SerializeField]
    private float timeBeforeWord;

    [SerializeField]
    private float timeBeforeTexts;

    [SerializeField]
    private GameObject black;

    [SerializeField]
    private GameObject kizKactiText;

    private void Start()
    {
        textMesh = this.GetComponent<TextMeshPro>();
        StartCoroutine(writeText());
        Invoke("KillTroy", 48);
        Invoke("PlayText", 51);
        Invoke("NextScene", 57);
    }

    private IEnumerator writeText()
    { 
        int i = 0;
        foreach (string text in texts)
        {
            foreach (char item in texts[i])
            {
                yield return new WaitForSeconds(timeBeforeWord);
                textMesh.text += item;
                SoundManager.Instance.playWordEffect();
            }
            yield return new WaitForSeconds(timeBeforeTexts);
            textMesh.text = string.Empty;
            i++;
            //yield return new WaitForSeconds(timeBeforeTexts);
        }

    }

    void KillTroy()
    {
        black.SetActive(true);
        SoundManager.Instance.PlayLaserShootEffect();
    }

    void PlayText()
    {
        kizKactiText.SetActive(true);
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
