using PickUps.Effect;
using UnityEngine;

namespace PickUps.PowerUp
{
    public class PowerUp_Health : PowerUp_Base
    {
        [SerializeField] private EffectHealth Health;

        protected override EffectBase InitEffect()
        {
            return Health;
        }
    }
}