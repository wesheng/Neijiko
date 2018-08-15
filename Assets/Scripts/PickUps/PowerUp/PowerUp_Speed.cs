using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Speed : PowerUp_Base
{

    [SerializeField] private float duration;
    [SerializeField] private float speedAddition;

    public override void OnCollisionEnter(Collision hit)
    {
        Debug.Log(hit.gameObject.name);
    }

    public override void GiveEffect(NejikoController controller)
    {
        controller.AddEffect<Effect_Speed>(duration, speedAddition);
    }
}
