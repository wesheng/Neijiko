using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Speed : Effect_Base
{
    public float speed;

    public Effect_Speed(float duration, float argument) : base(duration)
    {
        speed = argument;
    }

    public override void EffectStart(NejikoController controller)
    {
        controller.speedZ += speed;
    }

    public override void EffectUpdate(NejikoController controller)
    {
        
    }

    public override void EffectEnd(NejikoController controller)
    {
        controller.speedZ -= speed;
    }
}
