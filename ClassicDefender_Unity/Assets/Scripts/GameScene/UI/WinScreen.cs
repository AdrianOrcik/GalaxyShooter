using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : ScreenBase
{
    public Button RestartBtn;
    public Button NextBtn;

    private void Start()
    {
        RestartBtn.onClick.AddListener(OnRestartLevel);
        NextBtn.onClick.AddListener(OnNextLevel);
    }

    private void OnRestartLevel()
    {
        SceneManager.LoadScene(2);
    }

    private void OnNextLevel()
    {
        if (GameManager.GameDataLoader.GameData.PlayerData.PlusLevel())
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
            
        }
        else
        {
            Debug.Log("Next Level is not define");
        }
    }
}