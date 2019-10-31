﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    // Music should persist through scenes. Singleton
    private void Awake() 
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
}
