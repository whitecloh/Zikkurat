using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TweenSystem.Tweens
{
    [CreateAssetMenu(menuName = "Tween/Rotation", order = 51)]
    public class RotationTween : SOTween
    {
        [SerializeField] private Vector3 _start;
        [SerializeField] private Vector3 _target;

        private Quaternion startRotation => Quaternion.Euler(_start);
        private Quaternion targetRotation => Quaternion.Euler(_target);


        public override void ChangeState(GameObject gameObject, float currentTime)
        {
            var lerpValue = Parameters.GetLerpValue(currentTime);

            gameObject.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, lerpValue);
        }

        public override void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters)
        {
            var lerpValue = tweenParameters.GetLerpValue(currentTime);

            gameObject.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, lerpValue);
        }
    }
}