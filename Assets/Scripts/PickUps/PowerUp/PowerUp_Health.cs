using PickUps.Effect;
using UnityEngine;

namespace PickUps.PowerUp
{
    public class PowerUp_Health : PowerUp_Base
    {
        [SerializeField] private int HealthToGive = 1;

        protected override Effect_Base InitEffect()
        {
            return new Effect_Health(HealthToGive);
        }
    }
}