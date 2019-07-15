using System.Collections.Generic;
using GameScene.UI;
using UnityEngine;

/// <summary>
/// Class managing game screens for easy access to enable or disable screens
/// </summary>
public class ScreenManager : MainBehaviour
{
    private List<ScreenBase> Screens;

    public void Start()
    {
        Screens = new List<ScreenBase>();
        foreach (Transform transform in gameObject.transform)
        {
            Screens.Add(transform.GetComponent<ScreenBase>());
        }
    }

    public void ActiveWinScreen()
    {
        ActiveScreen(ScreenType.WinScreen);
    }

    public void ActiveLoseScreen()
    {
        ActiveScreen(ScreenType.LoseScreen);
    }

    public void ActiveScreen(ScreenType type, bool toActive = true)
    {
        foreach (ScreenBase screen in Screens)
        {
            if (screen.ScreenType == type)
            {
                screen.gameObject.SetActive(toActive);
            }
        }
    }
}