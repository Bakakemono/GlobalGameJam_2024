using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_MaxFov", menuName = "ScriptableObjects/MaxFovEffect")]
public class MaxFov : Choice
{
    public override void Effect() {
        FindObjectOfType<Camera>().fieldOfView = 130f;
    }
}
