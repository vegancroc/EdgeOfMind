using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerNextScene : MonoBehaviour
{
    [SerializeField]
    private float duration;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Variables.scene2Trigger = true;
            Invoke("nextScene", duration);
        }
    }

    void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
