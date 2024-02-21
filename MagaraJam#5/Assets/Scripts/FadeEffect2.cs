using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeEffect2 : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = this.GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        if (Variables.scene2Trigger)
        {
            image.color += new Color(0, 0, 0, .04f);
        }
    }
}
