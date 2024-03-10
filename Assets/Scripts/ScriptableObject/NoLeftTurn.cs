using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_NoLeftTurn", menuName = "ScriptableObjects/NoLeftTurnEffect")]
public class NoLeftTurn : Choice
{
    public override void Effect() {
        FindObjectOfType<PlayerController>().DisableTurningLeft();
    }
}
