using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private bool inildi = false;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    { 
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
   
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" && inildi == false)
        {
            StartCoroutine(shaking());
            Invoke("movePass", 6);
        }
    }

    private IEnumerator shaking()
    {
        SoundManager.Instance.playFallDownEffect();
        noise.m_FrequencyGain = 1;
        yield return new WaitForSeconds(duration);
        noise.m_FrequencyGain = 0;
        inildi = true;
    }

    private void movePass()
    {
        Variables.moveable = true;
    }

}
