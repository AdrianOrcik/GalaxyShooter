using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileController : InputGameController
{
    public PlayerMobileController()
    {
    }

    public override void GameController()
    {
        Vector3 direction =
            new Vector3(SimpleInput.GetAxis("Horizontal") * Constants.JOYSTICK_SENSITICITY,
                SimpleInput.GetAxis("Vertical") * Constants.JOYSTICK_SENSITICITY,
                0);
        playerBehaviour.Move(direction);
    }
}