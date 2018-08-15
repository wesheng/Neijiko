using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp_Base
{
    [SerializeField] private float duration;
    [SerializeField] private float speedAddition;

    protected override Effect_Base InitEffect()
    {
        return new Effect_Speed(duration, speedAddition);
    }
}
