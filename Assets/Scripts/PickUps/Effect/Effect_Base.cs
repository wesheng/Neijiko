using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect_Base
{
    public float remainingTime = 0;    

    protected Effect_Base(float duration)
    {
        remainingTime = duration;
    }
   
    public abstract void EffectStart(NejikoController controller);
    public abstract void EffectUpdate(NejikoController controller);
    public abstract void EffectEnd(NejikoController controller);

    public virtual IEnumerator EffectCoroutine(NejikoController controller)
    {
        yield return null;
    }
}
