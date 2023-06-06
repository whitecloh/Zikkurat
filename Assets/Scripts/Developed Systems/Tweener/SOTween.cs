using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TweenSystem
{
    public abstract class SOTween : ScriptableObject, ITween
    {
        [SerializeField] private TweenParameters _tweenParameters;
        public TweenParameters Parameters => _tweenParameters;


        public abstract void ChangeState(GameObject gameObject, float currentTime);
        public abstract void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters);
    }
}