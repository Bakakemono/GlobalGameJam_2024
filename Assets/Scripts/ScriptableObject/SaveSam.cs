using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SaveSam", menuName = "ScriptableObjects/SaveSamEffect")]

public class SaveSam : Choice
{
    public override void Effect() {
        FindObjectsOfType<Pan>()[0].gameObject.SetActive(true);
    }
}
