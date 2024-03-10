using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_RemoveJump", menuName = "ScriptableObjects/RemoveJumpEffect")]
public class RemoveJump : Choice
{
    public override void Effect() {
        FindObjectOfType<PlayerController>().DisableJump();
    }
}
