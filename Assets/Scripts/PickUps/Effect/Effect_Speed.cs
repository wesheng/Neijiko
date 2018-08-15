using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Speed : Effect_Base
{
    public float speed;

    public Effect_Speed(float duration, float argument) : base(duration, argument)
    {
        speed = argument;
    }

    public override void EffectStart(float duration)
    {
        GlobalInfo.NejikoController.speedZ += speed;
    }

    public override void EffectEnd()
    {
        GlobalInfo.NejikoController.speedZ -= speed;
    }
}
