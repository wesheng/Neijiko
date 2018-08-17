using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp_Base
{
    [SerializeField] private float duration;
    [SerializeField] private float speedAddition;

    protected override EffectBase InitEffect()
    {
        return null;
        //return new EffectSpeed(duration, speedAddition);
    }
}
