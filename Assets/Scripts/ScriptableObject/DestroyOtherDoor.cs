using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_DestroyDoor", menuName = "ScriptableObjects/DestroyDoorEffect")]
public class DestroyOtherDoor : Choice
{
    public bool _destroyLeftDoor = false;
    public override void Effect() {
        Door[] doors = FindObjectsOfType<Door>();
        if(_destroyLeftDoor) {
            if(doors[0]._isLeftDoor) {
                Destroy(doors[0].gameObject);
            }
            else {
                Destroy(doors[1].gameObject);
            }
        }
        else {
            if(!doors[0]._isLeftDoor) {
                Destroy(doors[0].gameObject);
            }
            else {
                Destroy(doors[1].gameObject);
            }
        }
    }
}
