using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TweenSystem
{
    public interface ITween
    {
        TweenParameters Parameters { get; }

        void ChangeState(GameObject gameObject, float currentTime);
        void ChangeState(GameObject gameObject, float currentTime, TweenParameters tweenParameters);
    }
}