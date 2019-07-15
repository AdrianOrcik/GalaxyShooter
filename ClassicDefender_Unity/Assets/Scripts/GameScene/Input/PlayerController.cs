using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : InputGameController
{
    public PlayerController()
    {
    }

    public override void GameController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerBehaviour.PlayerMove += Vector3.up.normalized * -1;

            playerBehaviour.Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerBehaviour.PlayerMove += Vector3.left.normalized * -1;
            playerBehaviour.Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerBehaviour.PlayerMove += Vector3.down.normalized * -1;
            playerBehaviour.Move(Vector3.down);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerBehaviour.PlayerMove += Vector3.right.normalized * -2;
            playerBehaviour.Move(Vector3.right);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerBehaviour.Shot();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerBehaviour.UIPanelBehaviour.ActiveMissile();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            playerBehaviour.UIPanelBehaviour.ActiveShot();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D))
        {
            playerBehaviour.PlayerMove = Vector3.zero;
        }
    }
}