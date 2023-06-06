using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Settings
{
    [CreateAssetMenu()]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float _ballSpeedStart;
        [SerializeField] private float _ballSpeedIncrease;
        [SerializeField] private float _ballSpeedMax;

        [SerializeField] private float _paddleSpeed;

        [SerializeField] private int _health;

        public float BallSpeedStart => _ballSpeedStart;
        public float BallSpeedIncrease => _ballSpeedIncrease;
        public float BallSpeedMax => _ballSpeedMax;

        public float PaddleSpeed => _paddleSpeed;

        public int Health => _health;
    }
}