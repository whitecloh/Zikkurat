using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Camera
{
    public class CameraHandler : MonoBehaviour
    {
        public Vector3 LookDirection { get => transform.forward; set => SetDirection(value); }
        public Vector3 Position { get => transform.position; set => transform.position = value; }

        [SerializeField] private Vector2 sensitivity;
        [SerializeField] private Vector2 verticalAngleLimits;

        // [SerializeField] private UnityEngine.Camera orbitCamera;


        public void Rotate(Vector2 rotationInput)
        {
            var horizontalAngle = GetHorizontalAngle(rotationInput.x);
            var verticalAngle = GetVerticalAngle(-rotationInput.y);

            transform.eulerAngles = new Vector3(verticalAngle, horizontalAngle);
        }

        public void Move(Vector3 positionInput)
        {
            Position += positionInput;
        }


        public void SetDirection(Vector3 direction)
        {
            var orientation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = orientation;
        }



        private float GetHorizontalAngle(float input)
        {
            return transform.eulerAngles.y + input * sensitivity.x;
        }

        private float GetVerticalAngle(float input)
        {
            var verticalAngle = GetAngleNormalized(transform.eulerAngles.x);

            if (IsAllowedToTurn(verticalAngle, input))
                return Mathf.Clamp(verticalAngle + input * sensitivity.y, verticalAngleLimits.x, verticalAngleLimits.y);

            return verticalAngle;
        }

        private bool IsAllowedToTurn(float verticalAngle, float verticalInput)
        {
            if (verticalInput > 0)
                return verticalAngle < verticalAngleLimits.y;

            if (verticalInput < 0)
                return verticalAngle > verticalAngleLimits.x;

            return false;
        }

        /// <summary>
        /// Transforms vertical angle from camera euler form to deviation from forward
        /// </summary>
        /// <param name="rawAngle">Vertical camera angle</param>
        private float GetAngleNormalized(float rawAngle)
        {
            if (rawAngle > 180)
                return rawAngle - 360;

            return rawAngle;
        }
    }
}