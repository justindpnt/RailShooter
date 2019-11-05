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
    [SerializeField] int hits = 10;

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
        hits--;
        if(hits <= 0)
        {
            scoreBoard.ScoreHit(scorePerHit);
            KillEnemy();
        }
    }

    //Generate explosion and remove enemy
    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
