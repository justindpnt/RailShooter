using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To prevent clutter during runtime
public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 5f;

    //Destroy the explosion after a set amount of time
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
