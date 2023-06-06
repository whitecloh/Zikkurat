using System;
using System.Collections;
using System.Collections.Generic;
using Developed.Extentions;
using UnityEngine;


namespace TweenSystem
{
    [Serializable]
    public struct TweenParameters
    {
        [SerializeField] private TweenStyle _tweenStyle;
        [SerializeField] private float _length;
        [SerializeField] private AnimationCurve _curve;

        public TweenStyle Style => _tweenStyle;
        public float Length => _length;


        internal TweenParameters(TweenStyle tweenStyle, float length, AnimationCurve curve)
        {
            this._tweenStyle = tweenStyle;
            this._length = length;
            this._curve = curve;
        }


        public float GetLerpValue(float currentTime)
        {
            var lerpUnclamped = currentTime / Length;
            var lerp = 0f;

            switch (Style)
            {
                default:
                case TweenStyle.FixedTime:
                    lerp = FixedTimeLerp(lerpUnclamped);
                    break;

                case TweenStyle.Loop:
                    lerp = LoopLerp(lerpUnclamped);
                    break;

                case TweenStyle.PingPong:
                    lerp = PingPongLerp(lerpUnclamped);
                    break;
            }

            return _curve.Evaluate(lerp);
        }


        public bool IsFinished(float currentTime)
        {
            var lerpUnclamped = currentTime / Length;

            return lerpUnclamped >= 1 && Style == TweenStyle.FixedTime;
        }



        private float PingPongLerp(float lerpUnclamped)
        {
            var intPart = Mathf.FloorToInt(lerpUnclamped);

            if (MathCustom.IsEvenNumber(intPart))
                return LoopLerp(lerpUnclamped);
            else
                return 1 - LoopLerp(lerpUnclamped);
        }

        private float LoopLerp(float lerpUnclamped)
        {
            return lerpUnclamped % 1;
        }

        private float FixedTimeLerp(float lerpUnclamped)
        {
            return Mathf.Clamp(lerpUnclamped, 0, 1);
        }
    }
}