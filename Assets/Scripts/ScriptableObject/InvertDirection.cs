using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_InvertDirection", menuName = "ScriptableObjects/InvertDirectionEffect")]
public class InvertDirection : Choice
{
    public override void Effect() {
        FindObjectOfType<PlayerController>().InverseControl();
    }
}
