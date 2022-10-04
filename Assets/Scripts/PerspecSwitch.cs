using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspecSwitch : MonoBehaviour
{
    public MouseLook mouseLook;
    public PlayerMovement playerMovement;
    public ThirdPersonMovement thirdPersonMovement;

    bool firstperson = true;
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonMovement.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && firstperson)
        {
            mouseLook.enabled = false;
            playerMovement.enabled = false;

            thirdPersonMovement.enabled = true;
            firstperson = false;

        }

        if (Input.GetMouseButtonDown(1) && !firstperson)
        {
            mouseLook.enabled = true;
            playerMovement.enabled = true;

            thirdPersonMovement.enabled = false;
            firstperson = true;

        }
    }

}