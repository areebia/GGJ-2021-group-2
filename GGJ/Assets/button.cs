﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button : MonoBehaviour
{

    public void playAgain()
    {
        SceneManager.LoadScene(2);
    }


    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
    /*
    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
    */
    // Start is called before the first frame update
    void Start()
    {
         Cursor.visible = true;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
