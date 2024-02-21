using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene5Scripts : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    [SerializeField]
    private Image image;

    private void Start()
    {
        StartCoroutine(FlashEffect()); 
    }

    private IEnumerator FlashEffect()
    {
        //yield return new WaitForSeconds(1);
        //image.color += new Color(0, 0, 0, 255);
        //SoundManager.Instance.PlayLaserShootEffect();
        //yield return new WaitForSeconds(.1f);
        //image.color -= new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(2);
        text.SetActive(true);
        yield return new WaitForSeconds(17);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
