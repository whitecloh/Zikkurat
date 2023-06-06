using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities.Unit
{
    public class Unit : MonoBehaviour, IUnit
    {
        public Color UnitColor => modelRenderer.material.color;

        public Vector3 Position { get => transform.position; set => transform.position = value; }
        public Vector3 Direction { get => transform.forward; set => SetDirection(value); }

        public UnitStats Stats { get; set; }
        public IUnitState State { get; set; }

        public IUnitActions Actions { get; set; }


        [SerializeField] private Renderer modelRenderer;


        public void SetColor(Color value)
        {
            modelRenderer.material.color = value;
        }

        public void SetDirection(Vector3 value)
        {
            var value2D = value;
            value2D.y = 0;

            transform.rotation = Quaternion.LookRotation(value2D, Vector3.up);
        }
    }
}