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

    [SerializeField] float _speed = 4f;
    [SerializeField] float _jumpHeight = 1f;
    [SerializeField] Transform _jumpDetectionBoxPos;
    [SerializeField] LayerMask _jumpLayerMask;

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

    bool _lock = false;

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

        _inputActionController.PlayerControl.Interact.performed += Interact;
        _inputActionController.PlayerControl.Interact.Enable();

        _inputActionController.PlayerControl.Jump.performed += DoJump;
        _inputActionController.PlayerControl.Jump.Enable();
    }

    private void FixedUpdate() {
        if(_lock) {
            _cameraTransform.forward = Vector3.Lerp(_cameraTransform.forward, Vector3.forward, 0.1f);
            return;
        }
        Vector3 input = _movement.ReadValue<Vector2>();

        Vector3 cameraForward = new Vector3(_cameraTransform.forward.x, 0, _cameraTransform.forward.z).normalized;
        _rigidbody.velocity = (cameraForward * input.y + new Vector3(cameraForward.z, 0, -cameraForward.x) * (_noLeftTurn && input.x < 0f ? 0f : input.x)).normalized * _speed + Vector3.up * _rigidbody.velocity.y;

        float mouseX = Input.GetAxis("Mouse X");
        if(!_noLeftTurn || (_noLeftTurn && mouseX > 0))
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

    private void DoJump(InputAction.CallbackContext context) {
        if(_noJump)
            return;

        if(Physics.OverlapBox(
            _jumpDetectionBoxPos.position, new Vector3(0.2f, 0.1f, 0.2f), Quaternion.identity, _jumpLayerMask).Length == 0)
            return;


        _rigidbody.velocity =
            new Vector3(
                _rigidbody.velocity.x,
                Mathf.Sqrt(2 * -Physics.gravity.y * (_jumpHeight + 0.2f)),
                _rigidbody.velocity.z
                );
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

    public void DisableTurningLeft() {
        _noLeftTurn = true;
    }
    
    public void LockPlayer() {
        _lock = true;
    }

    public void UnlockPlayer() {
        _lock = false;
    }
}
