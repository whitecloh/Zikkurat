using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TweenSystem.Tweens;

namespace TweenSystem
{
    [CreateAssetMenu(menuName = "Tween/Tween Collection", order = 51)]
    public class SOTweenCollection : SOTween
    {
        [SerializeField] private TweenRecord[] _tweens;


        public override void ChangeState(GameObject gameObject, float currentTime)
        {
            foreach (TweenRecord tween in _tweens)
                if (tween.OverrideParameters)
                    tween.Tween.ChangeState(gameObject, currentTime);
                else
                    tween.Tween.ChangeState(gameObject, currentTime, Parameters);
        }

        public override void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters)
        {
            foreach (TweenRecord tween in _tweens)
                if (tween.OverrideParameters)
                    tween.Tween.ChangeState(gameObject, currentTime);
                else
                    tween.Tween.ChangeState(gameObject, currentTime, tweenParameters);
        }



        [System.Serializable]
        private struct TweenRecord
        {
            public SOTween Tween;
            public bool OverrideParameters;
        }
    }
}