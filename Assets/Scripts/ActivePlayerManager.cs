using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePlayerManager : MonoBehaviour
{
    private static ActivePlayerManager instance;
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private GameObject canvas;
    private float currentTurnTime = 10;
    [SerializeField] private float turnTimeLimit = 11f;

    private int currentPlayer;

    // If no other instance exists, set reference to self and set player turn
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayer = 1;
            camera2.SetActive(false);
        }
    }

    // Used to reference functions of this script in others
    public static ActivePlayerManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayer == 1)
        {
            currentPlayer = 2;
            // Change the active camera
            camera1.SetActive(false);
            camera2.SetActive(true);
            Debug.Log("Changed turn to player 2");
        }
        else if (currentPlayer == 2)
        {
            currentPlayer = 1;
            camera2.SetActive(false);
            camera1.SetActive(true);
            Debug.Log("Changed turn to player 1");
        }
        
    }

    // Used by the player controller to check who's turn it is
    public bool IsItMyTurn(int index)
    {
        if (index == currentPlayer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        currentTurnTime -= Time.deltaTime;
        if (currentTurnTime <= 0)
        {
            ChangeTurn();
            currentTurnTime = turnTimeLimit;
        }
    }

    public float GetCurrentTime()
    {
        return currentTurnTime;
    }

    public int GetPlayerTurn()
    {
        return currentPlayer;
    }
}