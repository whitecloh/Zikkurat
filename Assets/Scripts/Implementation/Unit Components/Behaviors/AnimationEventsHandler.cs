using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities.Unit
{
    public class AnimationEventsHandler : MonoBehaviour
    {
        public event Action AttackStarted;
        public event Action AttackEnded;

        public event Action ActionEnded;


        private void OnAttackStart_UnityEditor()
        {
            AttackStarted?.Invoke();
        }

        private void OnAttackEnd_UnityEditor()
        {
            AttackEnded?.Invoke();
        }

        private void OnActionEnd_UnityEditor()
        {
            ActionEnded?.Invoke();
        }
    }
}