using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Scene laod manager
public class SceneLoader : MonoBehaviour
{
    //Load the first scene
    void Start() 
    {
        Invoke("LoadFirstScene", 2f);
    }

    //Manager to load the main game
    void LoadFirstScene() 
    {
        SceneManager.LoadScene(1);
    }
}
