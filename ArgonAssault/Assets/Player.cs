using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    //Cached references
    [Tooltip("In ms^-1")][SerializeField] float Speed = 4000f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Processtranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f); // Hardcoded for now. Understanding the order
    }

    private void Processtranslation() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
