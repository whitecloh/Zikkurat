using System;
using System.Collections;
using System.Collections.Generic;
using Game.Camera;
using UnityEngine;

namespace Game.Plugins.Input
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private InputReceiver _inputReceiver;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private CameraHandler _cameraHandler;

        private Vector3 _cameraMovementInput;
        private Vector2 _cameraRotationInput;


        // Start is called before the first frame update
        void OnEnable()
        {
            _inputReceiver.CameraMovement += OnCameraMovementUpdated;
            _inputReceiver.CameraAscension += OnCameraAscensionUpdated;
            _inputReceiver.CameraRotation += OnCameraRotationUpdated;
        }

        void OnDisable()
        {
            _inputReceiver.CameraMovement -= OnCameraMovementUpdated;
            _inputReceiver.CameraAscension -= OnCameraAscensionUpdated;
            _inputReceiver.CameraRotation -= OnCameraRotationUpdated;
        }


        // Update is called once per frame
        void LateUpdate()
        {
            MoveCamera();
            RotateCamera();
        }



        private void MoveCamera()
        {
            // var resultInput = new Vector3(_cameraMovementInput.x, 0, _cameraMovementInput.y);
            _cameraHandler.transform.Translate((_cameraMovementInput * _movementSpeed * Time.deltaTime), Space.Self);
        }

        private void RotateCamera()
        {
            _cameraHandler.Rotate(_cameraRotationInput);
        }


        private void OnCameraRotationUpdated(Vector2 value) => _cameraRotationInput = value;

        private void OnCameraMovementUpdated(Vector2 value)
        {
            _cameraMovementInput.x = value.x;
            _cameraMovementInput.z = value.y;
        }

        private void OnCameraAscensionUpdated(float value)
        {
            _cameraMovementInput.y = value;
        }
    }
}