using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TweenSystem.Tweens
{
    [CreateAssetMenu(menuName = "Tween/Scale", order = 51)]
    public class ScaleTween : SOTween
    {
        [SerializeField] private Vector3 start;
        [SerializeField] private Vector3 target;

        [SerializeField] private bool controlX;
        [SerializeField] private bool controlY;
        [SerializeField] private bool controlZ;


        public override void ChangeState(GameObject gameObject, float currentTime)
        {
            var lerpValue = Parameters.GetLerpValue(currentTime);

            gameObject.transform.localScale = GetCorrectScale(gameObject.transform.localPosition, lerpValue);
        }

        public override void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters)
        {
            var lerpValue = tweenParameters.GetLerpValue(currentTime);

            gameObject.transform.localScale = GetCorrectScale(gameObject.transform.localPosition, lerpValue);
        }



        private Vector3 GetCorrectScale(Vector3 currentScale, float lerpValue)
        {
            var fullControlledVector = Vector3.LerpUnclamped(start, target, lerpValue);

            return new Vector3(controlX ? fullControlledVector.x : currentScale.x,
                controlY ? fullControlledVector.y : currentScale.y,
                controlZ ? fullControlledVector.z : currentScale.z);
        }
    }
}