using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera thirdPersonCam;
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    [SerializeField] private int playerIndex;

    private void OnEnable()
    {
        CameraSwitcher.Register(thirdPersonCam);
        CameraSwitcher.Register(firstPersonCam);
        CameraSwitcher.SwitchCamera(thirdPersonCam);
    }

    private void OnDisable()
    {
        CameraSwitcher.Unregister(thirdPersonCam);
        CameraSwitcher.Unregister(firstPersonCam);
    }

    
    void Update()
    {
        if (ActivePlayerManager.GetInstance().IsItMyTurn(playerIndex))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (CameraSwitcher.IsActiveCamera(thirdPersonCam))
                {
                    CameraSwitcher.SwitchCamera(firstPersonCam);
                }
                else if (CameraSwitcher.IsActiveCamera(firstPersonCam))
                {
                    CameraSwitcher.SwitchCamera(thirdPersonCam);
                }
            }
        }
    }
    public int GetIndex()
    {
        return playerIndex;
    }
}
