using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField] Transform _enteryDoorLocation;
    [SerializeField] Transform _leftDoorLocation;
    [SerializeField] Transform _rightDoorLocation;

    Vector3 _relativePosInFrontOfDoor = Vector3.back;

    [SerializeField] List<Choice> _choices;
    private void Start() {
        _playerController = FindObjectOfType<PlayerController>();
        _playerTransform = _playerController.transform;
    }
    int currentIndex = 0;

    public void OpenLeftDoor() {
        _playerTransform.GetComponent<Rigidbody>().isKinematic = true;
        if(currentIndex + 1 < _choices.Count)
            _choices[currentIndex].Effect();

        _playerController.LockPlayer();
        _aimedDoor = _leftDoorLocation;
        _step = DoorCrossingStep.CENTERING;
        currentIndex += 2;
    }
    public void OpenRightDoor() {
        _playerTransform.GetComponent<Rigidbody>().isKinematic = true;
        if(currentIndex + 1 < _choices.Count)
            _choices[currentIndex + 1].Effect();

        _playerController.LockPlayer();
        _aimedDoor = _rightDoorLocation;
        _step = DoorCrossingStep.CENTERING;
        currentIndex += 2;
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
                _playerTransform.position = new Vector3(_enteryDoorLocation.position.x, 0, _enteryDoorLocation.position.z) + _relativePosInFrontOfDoor + Vector3.up * 0.9f;
                _step = DoorCrossingStep.CROSSING_FRONTDOOR;
                break;
            case DoorCrossingStep.CROSSING_FRONTDOOR:
                Vector3 newPos = new Vector3(_enteryDoorLocation.position.x, 0, _enteryDoorLocation.position.z) + Vector3.forward * 1f + Vector3.up * 0.9f;
                _playerTransform.position = Vector3.Lerp(_playerTransform.position, newPos, 0.5f * Time.fixedDeltaTime);

                if((_playerTransform.position - newPos).sqrMagnitude < 0.1f * 0.1f) {
                    _playerTransform.position = newPos;
                    _step = DoorCrossingStep.CROSSED;
                    _playerTransform.GetComponent<Rigidbody>().isKinematic = false;
                    _playerController.UnlockPlayer();
                }
                break;
            case DoorCrossingStep.CROSSED:
                break;
        }
    }

    void SetPlayerAtFirstDoor() {
        _playerTransform.position = _enteryDoorLocation.position;
    }
}
