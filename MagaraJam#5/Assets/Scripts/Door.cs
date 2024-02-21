using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public int killToOpenDoor;
    
    [SerializeField]
    Key key;
    private Animator anim;
    private LevelFadeEffect fade;
    
    void Start()
    {
        anim = this.GetComponent<Animator>();
        fade = this.GetComponent<LevelFadeEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && killToOpenDoor == key.getKillCount() && key.getIsKeyPickedUp())
        {
            SoundManager.Instance.PlayDoorOpen();
            anim.SetTrigger("open");
            startFadeEffect();
            Invoke("loadNextScene", 2);
        }
    }

    private void startFadeEffect()
    {
        fade.pass = true;
    }

    private void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
