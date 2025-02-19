﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void loadLobbyScene()
    {
        SceneManager.LoadScene("LobbyLoader");
    }
    public void LoadCreateLobbyScene()
    {
        SceneManager.LoadScene("CreateLevel");
    }
    public void LoadJoinLobbyScene()
    {
        SceneManager.LoadScene("TypeLobby");
    }
    public void LoadTeacherMainMenu()
    {
        SceneManager.LoadScene("MainMenuTeacher");
    }
    public void LoadStudentMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSplash()
    {
        SceneManager.LoadScene("Splash");
    }
    public void QuitApplicationExec()
    {
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
