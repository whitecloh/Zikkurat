// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace TweenSystem
// {
//     [Serializable]
//     public class EffectParameters : TweenParameters
//     {
//         public override TweenStyle currentStyle => defaultStyle && tweenData != null ? tweenData.tweenParameters.currentStyle : _tweenStyle;
//         public override float currentLength => defaultLength && tweenData != null ? tweenData.tweenParameters.currentLength : _length;

//         private bool defaultStyle = true;
//         private bool defaultLength = true;

//         protected ITweenData tweenData { get; private set; }


//         internal EffectParameters(ITweenData tweenData) : base(tweenData.tweenParameters.currentStyle, tweenData.tweenParameters.currentLength)
//         {
//             SetTweenData(tweenData);
//         }


//         public override void SetLength(float length)
//         {
//             base.SetLength(length);
//             defaultLength = false;
//         }

//         public override void SetTweenStyle(TweenStyle tweenStyle)
//         {
//             base.SetTweenStyle(tweenStyle);
//             defaultStyle = false;
//         }

//         public virtual void ResetCustomParameters()
//         {
//             this.defaultLength = true;
//             this.defaultStyle = true;
//         }


//         public void SetTweenData(ITweenData tweenData) => this.tweenData = tweenData;
//     }
// }