using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy functionality
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;

    ScoreBoard scoreBoard;

    //Start is called before the first frame update
    void Start() {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    //Initialize box collider on enemy ship
    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    //Handle the collison between the gun rays and the enemy ship
    void OnParticleCollision(GameObject other) 
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);   
    }
}
