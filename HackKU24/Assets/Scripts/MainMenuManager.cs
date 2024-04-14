using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene to Load")]
    [SerializeField] private SceneField _story;
    [SerializeField] private SceneField _settings;
    [SerializeField] private SceneField _credits;

    
    


    public void StartGame()
    {
        SceneManager.LoadScene(_story, LoadSceneMode.Single);
    }

    public void Settings()
    {
        SceneManager.LoadScene(_settings, LoadSceneMode.Single);
    }

    public void Credits()
    {
        SceneManager.LoadScene(_credits, LoadSceneMode.Single);
    }

}