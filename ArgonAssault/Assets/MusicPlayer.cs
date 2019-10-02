using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Music should persist through scenes
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }

    // Manager to load the main game
    void LoadFirstScene() 
    {
        SceneManager.LoadScene(1);
    }
}
