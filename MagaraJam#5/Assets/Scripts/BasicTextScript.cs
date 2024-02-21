using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BasicTextScript : MonoBehaviour
{

    [SerializeField]
    [TextArea]
    private string[] texts;

    private TextMeshPro textMesh;

    [SerializeField]
    private float timeBeforeWord;

    [SerializeField]
    private float timeBeforeTexts;

    private void Start()
    {
        textMesh = this.GetComponent<TextMeshPro>();
        StartCoroutine(writeText());
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
}
