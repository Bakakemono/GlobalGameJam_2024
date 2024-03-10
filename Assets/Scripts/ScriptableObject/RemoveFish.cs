using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_RemoveFish", menuName = "ScriptableObjects/RemoveFishEffect")]
public class RemoveFish : Choice
{
    public override void Effect() {
        Destroy(FindObjectOfType<Fish>().gameObject);
    }
}
