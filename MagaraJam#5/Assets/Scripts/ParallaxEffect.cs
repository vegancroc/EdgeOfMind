using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private float parallaxEffectMultiplier;

    [SerializeField]
    private float parallaxEffectMultiplierY;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    #endregion

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }
    #region Functions
    private void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplierY);
        lastCameraPosition = cameraTransform.position;
    }
    #endregion


}
