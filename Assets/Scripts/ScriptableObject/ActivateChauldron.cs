using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_ActivateChauldron", menuName = "ScriptableObjects/ActivateChauldronEffect")]
public class ActivateChauldron : Choice
{
    public override void Effect() {
        FindObjectOfType<Chauldron>()._ChauldronContent.SetActive(true);
    }
}
