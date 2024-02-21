using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFadeEffect : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [System.NonSerialized]
    public bool pass;

    private void FixedUpdate()
    {
        if (pass)
        {
            image.color += new Color(0, 0, 0, .04f);
        }
    }
}
