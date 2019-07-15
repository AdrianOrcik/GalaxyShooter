using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations; 
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationControllers", menuName = "AnimationControllers")]
public class AnimationScriptable : ScriptableObject
{
    //I had problem with Animation Controllers cause AnimatorController is linked to UnityEditor.Animations
    //public AnimatorController[] AnimatorControllers;
}