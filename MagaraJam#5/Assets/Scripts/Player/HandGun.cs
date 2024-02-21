using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;


    [SerializeField] private GameObject laser;
    [SerializeField] private Transform laserPoint;
    

    [SerializeField]private Transform parentTransform;
    void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {      
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;


        if(Variables.moveable)
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (parentTransform.localScale.x < transform.localScale.x)
            transform.localScale = -1 * Vector2.one;

        if (parentTransform.localScale.x > transform.localScale.x)
            transform.localScale =Vector2.one;





        if (Input.GetMouseButton(0) && Variables.moveable)
        {
            
            laser.GetComponent<Laser>().setDirection(new Vector2(rotation.x, rotation.y));
            
        }

        
    }
}
