using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene005doorscript : MonoBehaviour
{
    private LevelFadeEffect effect;

    private void Start()
    {
        effect = this.GetComponent<LevelFadeEffect>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect.pass = true;
            Invoke("NextScene", 2);
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
