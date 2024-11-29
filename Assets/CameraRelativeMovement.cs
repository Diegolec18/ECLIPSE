using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRelativeMovement : MonoBehaviour
{
    float _horizontalInput;
    float _verticalInput;
    Vector3 _playerInput;
    [SerializeField] CharacterController _characterController;

    void Start()
    {
        // get the Character Controller component attached to the character
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // get and store player input every frame
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        // set it to the X and Z values of the Vector3
        _playerInput.x = _horizontalInput;
        _playerInput.z = _verticalInput;

        // rotate player input vector to camera space
        Vector3 cameraRelativeMovement = ConvertToCameraSpace(_playerInput);

        // transform position using Move and the rotated player input
        _characterController.Move(cameraRelativeMovement * Time.deltaTime);
    }

    Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
      // store the Y value of the original vector to rotate 
      float currentYValue = vectorToRotate.y;

      // get the forward and right directional vectors of the camera
      Vector3 cameraForward = Camera.main.transform.forward;
      Vector3 cameraRight = Camera.main.transform.right;

      // remove the Y values to ignore upward/downward camera angles
      cameraForward.y = 0;
      cameraRight.y = 0;

      // re-normalize both vectors so they each have a magnitude of 1
      cameraForward = cameraForward.normalized;
      cameraRight = cameraRight.normalized;

      // rotate the X and Z VectorToRotate values to camera space
      Vector3 cameraForwardZProduct = vectorToRotate.z * cameraForward;
      Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;

      // the sum of both products is the Vector3 in camera space and set Y value
      Vector3 vectorRotatedToCameraSpace = cameraForwardZProduct + cameraRightXProduct;
      vectorRotatedToCameraSpace.y = currentYValue;
      return vectorRotatedToCameraSpace;
    }
}
