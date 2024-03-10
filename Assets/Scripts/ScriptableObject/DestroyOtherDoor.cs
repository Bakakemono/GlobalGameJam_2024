using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_DestroyDoor", menuName = "ScriptableObjects/DestroyDoorEffect")]
public class DestroyOtherDoor : Choice
{
    public override void Effect() {
        Destroy(FindObjectOfType<Door>().gameObject);
    }
}
