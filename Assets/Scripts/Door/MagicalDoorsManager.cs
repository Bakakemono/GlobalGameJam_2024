using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MagicalDoorsManager : MonoBehaviour
{
    public enum DoorCrossingStep {
        CENTERING,
        TP_TO_FRONTDOOR,
        CROSSING_FRONTDOOR,
        CROSSED
    }

    DoorCrossingStep _step = DoorCrossingStep.CROSSED;
    Transform _aimedDoor;

    Transform _playerTransform;
    PlayerController _playerController;

    [SerializeField] Transform _entryDoorLocation;
    [SerializeField] Transform _leftDoorLocation;
    [SerializeField] Transform _rightDoorLocation;

    Vector3 _relativePosInFrontOfDoor = Vector3.back;

    [SerializeField] List<Choice> _choices;

    TextMeshProUGUI _textLeftDoor;
    TextMeshProUGUI _textRightDoor;
    TextMeshProUGUI _textEntryDoor;

    private void Start() {
        _playerController = FindObjectOfType<PlayerController>();
        _playerTransform = _playerController.transform;

        _textEntryDoor = _entryDoorLocation.GetComponentInChildren<TextMeshProUGUI>();
        _textLeftDoor = _leftDoorLocation.GetComponentInChildren<TextMeshProUGUI>();
        _textRightDoor = _rightDoorLocation.GetComponentInChildren<TextMeshProUGUI>();
        _textLeftDoor.text = _choices[_currentIndex]._doorMessage;
        _textRightDoor.text = _choices[_currentIndex + 1]._doorMessage;

    }
    int _currentIndex = 0;
    int _indexShift = 0;

    public void OpenLeftDoor() {
        _playerTransform.GetComponent<Rigidbody>().isKinematic = true;
        _indexShift = 0;

        _playerController.LockPlayer();
        _aimedDoor = _leftDoorLocation;
        _step = DoorCrossingStep.CENTERING;

        _textEntryDoor.text = _textLeftDoor.text;
    }

    public void OpenRightDoor() {
        _playerTransform.GetComponent<Rigidbody>().isKinematic = true;
        _indexShift = 1;

        _playerController.LockPlayer();
        _aimedDoor = _rightDoorLocation;
        _step = DoorCrossingStep.CENTERING;

        _textEntryDoor.text = _textRightDoor.text;
    }

    private void FixedUpdate() {
        switch(_step) {
            case DoorCrossingStep.CENTERING:
                Vector3 aimedPos = new Vector3(_aimedDoor.position.x, 0, _aimedDoor.position.z) + _relativePosInFrontOfDoor + Vector3.up * 0.9f;
                _playerTransform.position =
                    Vector3.Lerp(
                        _playerTransform.position,
                        aimedPos,
                        2.0f * Time.fixedDeltaTime
                        );
                if((_playerTransform.position - aimedPos).sqrMagnitude < 0.1f * 0.1f) {
                    _playerTransform.position = aimedPos;
                    _step = DoorCrossingStep.TP_TO_FRONTDOOR;
                }
                break;
            case DoorCrossingStep.TP_TO_FRONTDOOR:
                _playerTransform.position = new Vector3(_entryDoorLocation.position.x, 0, _entryDoorLocation.position.z) + _relativePosInFrontOfDoor + Vector3.up * 0.9f;
                _step = DoorCrossingStep.CROSSING_FRONTDOOR;
                _choices[_currentIndex + _indexShift].Effect();
                break;
            case DoorCrossingStep.CROSSING_FRONTDOOR:
                Vector3 newPos = new Vector3(_entryDoorLocation.position.x, 0, _entryDoorLocation.position.z) + Vector3.forward * 1f + Vector3.up * 0.9f;
                _playerTransform.position = Vector3.Lerp(_playerTransform.position, newPos, 1.0f * Time.fixedDeltaTime);

                if((_playerTransform.position - newPos).sqrMagnitude < 0.2f * 0.2f) {
                    _playerTransform.position = newPos;
                    _step = DoorCrossingStep.CROSSED;
                    _playerTransform.GetComponent<Rigidbody>().isKinematic = false;
                    _playerController.UnlockPlayer();
                    _currentIndex += 2;

                    _textLeftDoor.text = _choices[_currentIndex]._doorMessage;
                    _textRightDoor.text = _choices[_currentIndex + 1]._doorMessage;
                }
                break;
            case DoorCrossingStep.CROSSED:
                break;
        }
    }

    void SetPlayerAtFirstDoor() {
        _playerTransform.position = _entryDoorLocation.position;
    }
}
