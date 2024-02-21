using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scene6Script : MonoBehaviour
{
    [SerializeField]
    private float RedEffectStartTime;

    [SerializeField]
    private Image black;

    [SerializeField]
    private GameObject red;
    private void Start()
    {
        StartCoroutine(redEffect());
    }

    private void FixedUpdate()
    {
        black.color += new Color(0, 0, 0, -.01f);
    }

    private IEnumerator redEffect()
    {
        yield return new WaitForSeconds(RedEffectStartTime);
        SoundManager.Instance.PlayAlertEffect();
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        yield return new WaitForSeconds(.1f);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        yield return new WaitForSeconds(.1f);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        yield return new WaitForSeconds(.1f);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        yield return new WaitForSeconds(.1f);
        red.SetActive(true);
        yield return new WaitForSeconds(.1f);
        red.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
