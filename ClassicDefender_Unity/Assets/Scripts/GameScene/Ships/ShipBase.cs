using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class ShipBase : MainBehaviour
{
    public virtual void Kill()
    {
        Debug.Log("Base Kill");
    }
}