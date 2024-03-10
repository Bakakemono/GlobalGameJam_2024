using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_SaveTheRing", menuName = "ScriptableObjects/SaveTheRingEffect")]
public class SaveTheRing : Choice
{
    public override void Effect() {
        FindObjectsOfType<Tombstone>()[0].gameObject.SetActive(true);
    }
}
