using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    // Music should persist through scenes
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
