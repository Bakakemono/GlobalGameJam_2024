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

    //Camera Settings
    public float Sensitivity {
        get { return _sensitivity; }
        set { _sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float _sensitivity = 4f;
    float _minSensitivity = 0.5f;
    float _maxSensitivity = 12f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float _yRotationLimit = 88f;

    Vector2 _rotation = Vector2.zero;
    const string _xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
    const string _yAxis = "Mouse Y";

    //Interactions
    [SerializeField] LayerMask _doorLayer;

    //Restrictions
    bool _noJump = false;
    bool _noLeftTurn = false;
    bool _inverseControle = false;
    
    

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
        _mousePostion.Enable();

        _inputActionController.PlayerControl.Interact.performed += Interact;
        _inputActionController.PlayerControl.Interact.Enable();
    }

    private void FixedUpdate() {
        Vector3 input = _movement.ReadValue<Vector2>();

        Vector3 trueForward = new Vector3(_cameraTransform.forward.x, 0, _cameraTransform.forward.z).normalized;
        _rigidbody.velocity = (trueForward * input.y + new Vector3(trueForward.z, 0, -trueForward.x) * input.x).normalized * _speed + Vector3.up * _rigidbody.velocity.y;

        Vector2 mousePos = _mousePostion.ReadValue<Vector2>();
        _rotation.x += Input.GetAxis("Mouse X") * _sensitivity;
        _rotation.y += Input.GetAxis("Mouse Y") * _sensitivity;
        _rotation.y = Mathf.Clamp(_rotation.y, -_yRotationLimit, _yRotationLimit);
        var xQuat = Quaternion.AngleAxis(_rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(_rotation.y, Vector3.left);

        _cameraTransform.localRotation = xQuat * yQuat;
    }

    void Interact(InputAction.CallbackContext context) {
        RaycastHit hit;
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward, Color.red, 1f);
        if(Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, 1.5f, _doorLayer)) {
            hit.transform.GetComponent<Door>().OpenDoor();
        }
    }

    public void ModifyMouseSensitivity(bool increase) {
        _sensitivity = 
            increase ?
            _maxSensitivity :
            _minSensitivity;
    }

    public void DisableJump() {
        _noJump = true;
    }
}
