using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float SmoothTime = 0.1f;
    private Vector3 _lerpVelocity = Vector3.zero;
    public CharacterController _targetCharacter;
    float _currentOffset = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        transform.SetPositionAndRotation(new Vector3(_targetCharacter.transform.position.x, _targetCharacter.transform.position.y + 2, _targetCharacter.transform.position.z), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraRelativeVelocity = Camera.main.transform.InverseTransformVector(_targetCharacter.velocity);

        _currentOffset += cameraRelativeVelocity.x * Time.deltaTime;
        // _currentOffset = Mathf.Clamp(_currentOffset, , 6);

        
        Vector3 cameraRelativePosition = Camera.main.transform.InverseTransformVector(_targetCharacter.transform.position);

        Vector3 expectedPositionRelativeToCamera = new Vector3(cameraRelativePosition.x + _currentOffset, cameraRelativePosition.y, cameraRelativePosition.z);
        Vector3 expectedPositionRelativeToWorld = Camera.main.transform.TransformVector(expectedPositionRelativeToCamera);

        Vector3 expectedPositionWithYOffset = new Vector3(expectedPositionRelativeToWorld.x, expectedPositionRelativeToWorld.y + 2, expectedPositionRelativeToWorld.z);

        float expectedYPosition = expectedPositionRelativeToWorld.y + 2;


        if (_targetCharacter.isGrounded && cameraRelativeVelocity.magnitude != 0) {
            transform.SetPositionAndRotation(Vector3.Lerp(transform.position, expectedPositionWithYOffset, SmoothTime), Camera.main.transform.rotation);               
        // } else if (characterViewPos.y > 0.6f ||characterViewPos.y < 0.4f) {
        //     transform.SetPositionAndRotation(Vector3.SmoothDamp(transform.position, desiredPosition, ref _lerpVelocity, SmoothTime), transform.rotation);            
        }
        // else if (!_targetCharacter.isGrounded) {
        //     transform.SetPositionAndRotation(Vector3.SmoothDamp(transform.position, new Vector3(desiredPositionAsWorldVector.x, transform.position.y, desiredPositionAsWorldVector.z), ref _lerpVelocity, SmoothTime), transform.rotation);
        // }
    }
}
