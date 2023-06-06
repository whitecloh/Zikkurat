using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class PanelBehavior : MonoBehaviour
    {
        [SerializeField] private Vector3 _expandPosition;
        [SerializeField] private Vector3 _offPosition;

        [SerializeField] private TweenSystem.TweenParameters _tweenParameters;
        [SerializeField] private TweenSystem.SOTweenComponent _tweener;

        [SerializeField] private CanvasGroup _panel;

        private RectTransformMovementTween _movementTween;

        private bool _isExpand = false;


        private void Awake()
        {
            _movementTween = new RectTransformMovementTween(_tweenParameters);

            _movementTween.Start = _offPosition;
            _movementTween.End = _expandPosition;
        }


        public void Expand()
        {
            if (_tweener.IsPlaying)
            {
                StopAllCoroutines();
                _tweener.Stop();
            }

            _movementTween.Start = _offPosition;
            _movementTween.End = _expandPosition;

            _tweener.Play(_movementTween);
            _isExpand = true;

            StartCoroutine(ControlInteractionsProcess());
        }

        public void Hide()
        {
            if (_tweener.IsPlaying)
            {
                StopAllCoroutines();
                _tweener.Stop();
            }

            _movementTween.Start = _expandPosition;
            _movementTween.End = _offPosition;

            _tweener.Play(_movementTween);
            _isExpand = false;

            StartCoroutine(ControlInteractionsProcess());
        }


        public void ReverseState()
        {
            if (_isExpand)
                Hide();
            else
                Expand();
        }



        private IEnumerator ControlInteractionsProcess()
        {
            _panel.interactable = false;

            yield return null;

            while (_tweener.IsPlaying)
                yield return null;

            _panel.interactable = true;
        }
    }
}