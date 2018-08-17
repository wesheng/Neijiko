using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp_Base : MonoBehaviour
{

    private EffectBase effect;

    void Start()
    {
        effect = InitEffect();
    }

    protected abstract EffectBase InitEffect();
    
    public void GiveEffect(NejikoController controller)
    {
        controller.AddEffect(effect);
    }
}
