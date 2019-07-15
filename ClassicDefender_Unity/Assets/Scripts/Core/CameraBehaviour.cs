using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraBehaviour : MainBehaviour
{
    public Camera Camera;

    public void Start()
    {
        Camera = GetComponent<Camera>();
    }

    public void MoveCameraScreen(int screen, bool easeIn = true)
    {
        if (easeIn)
        {
            Camera.transform.DOMoveX((screen * Camera.orthographicSize) + screen, 0.5f).SetEase(Ease.InOutExpo);
        }
        else
        {
            Camera.transform.DOMoveX(screen * Camera.orthographicSize, 0.5f).SetEase(Ease.OutExpo);
        }
    }
}