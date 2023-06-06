using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitSpawnData
{
    public Color UnitColor;

    public Vector3 Position;
    public Vector3 Direction;

    public UnitStats Stats;


    public UnitSpawnData(Color UnitColor, Vector3 Position, Vector3 Direction, UnitStats Stats)
    {
        this.UnitColor = UnitColor;

        this.Position = Position;
        this.Direction = Direction;

        this.Stats = Stats;
    }
}
