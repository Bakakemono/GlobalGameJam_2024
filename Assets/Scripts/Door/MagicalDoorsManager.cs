using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class MagicalDoorsManager : MonoBehaviour
{
    Transform _player;

    [SerializeField] Transform _enteryDoorLocation;
    private void Start() {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    public void OpenLeftDoor() {
        SetPlayerAtFirstDoor();
    }
    public void OpenRightDoor() {
        SetPlayerAtFirstDoor();
    }

    void SetPlayerAtFirstDoor() {
        _player.position = _enteryDoorLocation.position;
    }
}
