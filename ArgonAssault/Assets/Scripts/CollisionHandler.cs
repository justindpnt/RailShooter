using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player died");
        SendMessage("OnPlayerDeath");
    }
}
