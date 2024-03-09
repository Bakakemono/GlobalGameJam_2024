using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SC_ModifyMouseSensitivity", menuName = "ScriptableObjects/MouseSensitivityEffect")]
public class ModifyMouseSensitivity : Choice
{
    public bool _increaseSensitivity = false;

    public override void Effect() {
        FindObjectOfType<PlayerController>().ModifyMouseSensitivity(_increaseSensitivity);
    }
}
