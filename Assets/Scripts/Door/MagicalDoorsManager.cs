using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class MagicalDoorsManager : MonoBehaviour
{
    Transform _player;

    [SerializeField] Transform _enteryDoorLocation;

    [SerializeField] List<Choice> _choices;
    private void Start() {
        _player = FindObjectOfType<PlayerController>().transform;
    }
    int currentIndex = 0;

    public void OpenLeftDoor() {
        SetPlayerAtFirstDoor();
        _choices[currentIndex].Effect();
        currentIndex += 2;
    }
    public void OpenRightDoor() {
        SetPlayerAtFirstDoor();
        _choices[currentIndex].Effect();
        currentIndex += 2;
    }

    void SetPlayerAtFirstDoor() {
        _player.position = _enteryDoorLocation.position;
    }
}
