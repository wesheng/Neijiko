using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect_Base {
    
    public float remainingTime = 0;    

    public Effect_Base(float duration, float argument)
    {
        remainingTime = duration;
    }
    
    public void PowerUpUpdate()
    {
        remainingTime -= Time.deltaTime;
    }

    public abstract void EffectStart(float duration);
    public abstract void EffectEnd();
}
