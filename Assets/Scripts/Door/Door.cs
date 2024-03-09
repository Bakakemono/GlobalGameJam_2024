using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool _isLeftDoor;

    MagicalDoorsManager _magicalDoorManager;

    private void Start() {
        _magicalDoorManager = FindObjectOfType<MagicalDoorsManager>();
    }

    public void OpenDoor() {
        if(_isLeftDoor) {
            _magicalDoorManager.OpenLeftDoor();
        }
        else {
            _magicalDoorManager.OpenRightDoor();
        }
    }
}
