using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TweenSystem
{
    public class SOTweenComponent : MonoBehaviour
    {
        public bool IsPlaying { get; private set; }
        //TODO: Reverse play will definitely be useful

        [SerializeField] protected float _defaultDelay = 0;
        [SerializeField] protected SOTween _defaultTween;


        /// <summary>
        /// Start playing
        /// </summary>
        public void Play()
        {
            Stop();
            StartPlay(_defaultTween);
        }

        /// <summary>
        /// Start playing provided tween
        /// </summary>
        public void Play(ITween tween)
        {
            Stop();

            // currentTweenSequence.Clear();

            // foreach (ITween tween in sequence)
            //     currentTweenSequence.Enqueue(tween);

            StartPlay(tween);
        }


        /// <summary>
        /// Stop currently playing tween
        /// </summary>
        public void Stop()
        {
            StopAllCoroutines();
            IsPlaying = false;
        }



        private void StartPlay(ITween tween)
        {
            StartCoroutine(PlayTween(tween));
        }

        private IEnumerator PlayTween(ITween tween)
        {
            IsPlaying = true;

            yield return new WaitForSeconds(_defaultDelay);

            float time = 0;

            while (!tween.Parameters.IsFinished(time))
            {
                time += Time.deltaTime;

                tween.ChangeState(gameObject, time);
                yield return null;
            }

            IsPlaying = false;
        }
    }
}