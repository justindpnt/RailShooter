using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Player ship collision functionality
public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    //Handle collison with any trigger in the environment
    void OnTriggerEnter(Collider other) 
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay); //String reference
    }

    //Start death sequence
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }

    //Restart the level after death
    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
