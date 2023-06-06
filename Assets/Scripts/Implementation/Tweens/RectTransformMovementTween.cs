using System.Collections;
using System.Collections.Generic;
using TweenSystem;
using UnityEngine;

namespace Game.UI
{
    public class RectTransformMovementTween : ITween
    {
        public TweenParameters Parameters { get; set; }

        public Vector3 Start { get; set; }
        public Vector3 End { get; set; }


        public RectTransformMovementTween()
        {
            this.Parameters = new TweenParameters();
        }

        public RectTransformMovementTween(TweenParameters parameters)
        {
            this.Parameters = parameters;
        }


        public void Reverse()
        {
            var temp = Start;
            Start = End;
            End = temp;
        }


        //TODO: Make tweens to not constantly get required component
        public void ChangeState(GameObject gameObject, float currentTime)
        {
            var lerpValue = Parameters.GetLerpValue(currentTime);
            var rectTransform = gameObject.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = Vector3.LerpUnclamped(Start, End, lerpValue);
        }

        public void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters)
        {
            var lerpValue = tweenParameters.GetLerpValue(currentTime);
            var rectTransform = gameObject.GetComponent<RectTransform>();

            rectTransform.anchoredPosition = Vector3.LerpUnclamped(Start, End, lerpValue);
        }
    }
}