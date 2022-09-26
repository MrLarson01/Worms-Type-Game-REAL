using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void Start ()
    {
        cam1.gameObject.active = true;
        cam2.gameObject.active = false;
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
