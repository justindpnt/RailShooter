using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//Player ship movement functionality
public class PlayerController : MonoBehaviour
{
    //Cached references
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float controlSpeed = 4000f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 5f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-throw Based")]
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float positionRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    //Update is called once per frame
    void Update() 
    {
        //If alive
        if (isControlEnabled)
        {
            Processtranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    void OnPlayerDeath() //called by string reference
    {  
        isControlEnabled = false; 
    }

    //Handle the rotation of the ship based off the screen position and joystick input
    private void ProcessRotation() 
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * positionRollFactor; 

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //Handle the movement of the ship based off the joystick input
    //Supports multiple controller inputs
    private void Processtranslation() 
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * controlSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach(GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }


}
