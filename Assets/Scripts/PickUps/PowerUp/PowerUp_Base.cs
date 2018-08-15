using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp_Base : MonoBehaviour
{

    private Effect_Base effect;

    void Start()
    {
        effect = InitEffect();
    }

    protected abstract Effect_Base InitEffect();
    
    public void GiveEffect(NejikoController controller)
    {
        controller.AddEffect(effect);
    }
}
