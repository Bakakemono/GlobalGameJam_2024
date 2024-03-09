using System;
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
        if(currentIndex + 1 < _choices.Count)
            _choices[currentIndex].Effect();

        SetPlayerAtFirstDoor();
        currentIndex += 2;
    }
    public void OpenRightDoor() {
        if(currentIndex + 1 < _choices.Count)
            _choices[currentIndex + 1].Effect();

        SetPlayerAtFirstDoor();
        currentIndex += 2;
    }

    void SetPlayerAtFirstDoor() {
        _player.position = _enteryDoorLocation.position;
    }
}
