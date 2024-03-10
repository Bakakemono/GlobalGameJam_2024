using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SO_RemoveGravity", menuName = "ScriptableObjects/RemoveGravityEffect")]
public class RemoveGravity : Choice
{
    public override void Effect() {
        FindObjectOfType<PlayerController>().DisableGravity();
    }
}
