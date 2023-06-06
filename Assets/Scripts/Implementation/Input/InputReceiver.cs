using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Plugins.Input
{
    public class InputReceiver : MonoBehaviour
    {
        public event Action<Vector2> CameraMovement;
        public event Action<float> CameraAscension;
        public event Action<Vector2> CameraRotation;

        private PlayerActions playerActions;


        void Awake()
        {
            InputSubscribe();
        }

        void OnDestroy()
        {
            InputUnsubscribe();
        }


        public void OnCameraMovementChanged(InputAction.CallbackContext context)
        {
            CameraMovement?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnCameraAscensionChanged(InputAction.CallbackContext context)
        {
            CameraAscension?.Invoke(context.ReadValue<float>());
        }

        public void OnCameraRotationChanged(InputAction.CallbackContext context)
        {
            CameraRotation?.Invoke(context.ReadValue<Vector2>());
        }



        private void InputSubscribe()
        {
            if (playerActions == null)
                playerActions = new PlayerActions();

            playerActions.Gameplay.CameraMovement.started += OnCameraMovementChanged;
            playerActions.Gameplay.CameraMovement.performed += OnCameraMovementChanged;
            playerActions.Gameplay.CameraMovement.canceled += OnCameraMovementChanged;

            playerActions.Gameplay.CameraAscention.started += OnCameraAscensionChanged;
            playerActions.Gameplay.CameraAscention.performed += OnCameraAscensionChanged;
            playerActions.Gameplay.CameraAscention.canceled += OnCameraAscensionChanged;

            playerActions.Gameplay.CameraRotation.started += OnCameraRotationChanged;
            playerActions.Gameplay.CameraRotation.performed += OnCameraRotationChanged;
            playerActions.Gameplay.CameraRotation.canceled += OnCameraRotationChanged;

            playerActions.Gameplay.Enable();
        }

        private void InputUnsubscribe()
        {
            playerActions.Gameplay.CameraMovement.started -= OnCameraMovementChanged;
            playerActions.Gameplay.CameraMovement.performed -= OnCameraMovementChanged;
            playerActions.Gameplay.CameraMovement.canceled -= OnCameraMovementChanged;

            playerActions.Gameplay.CameraAscention.started -= OnCameraAscensionChanged;
            playerActions.Gameplay.CameraAscention.performed -= OnCameraAscensionChanged;
            playerActions.Gameplay.CameraAscention.canceled -= OnCameraAscensionChanged;

            playerActions.Gameplay.CameraRotation.started -= OnCameraRotationChanged;
            playerActions.Gameplay.CameraRotation.performed -= OnCameraRotationChanged;
            playerActions.Gameplay.CameraRotation.canceled -= OnCameraRotationChanged;

            playerActions.Gameplay.Disable();
        }
    }
}