using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rigidbody;

    InputActionController _inputActionController;
    InputAction _movement;
    InputAction _mousePostion;

    Transform _cameraTransform;

    float _speed = 4f;

    public float Sensitivity {
        get { return _sensitivity; }
        set { _sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float _sensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float _yRotationLimit = 88f;

    Vector2 _rotation = Vector2.zero;
    const string _xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string _yAxis = "Mouse Y";

    private void Awake() {
        _inputActionController = new InputActionController();
        _rigidbody = GetComponent<Rigidbody>();

        _cameraTransform = GetComponentInChildren<Camera>().transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable() {
        _movement = _inputActionController.PlayerControl.Movement;
        _movement.Enable();

        _mousePostion = _inputActionController.PlayerControl.MousePosition;
    }

    private void FixedUpdate() {
        Vector3 input = _movement.ReadValue<Vector2>();

        Vector3 trueForward = new Vector3(_cameraTransform.forward.x, 0, _cameraTransform.forward.z).normalized;
        _rigidbody.velocity = trueForward * input.y * _speed;

        _rotation.x += Input.GetAxis(_xAxis) * _sensitivity;
        _rotation.y += Input.GetAxis(_yAxis) * _sensitivity;
        _rotation.y = Mathf.Clamp(_rotation.y, -_yRotationLimit, _yRotationLimit);
        var xQuat = Quaternion.AngleAxis(_rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(_rotation.y, Vector3.left);

        _cameraTransform.localRotation = xQuat * yQuat;

    }
}