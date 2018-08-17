using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Health")]
public class EffectHealth : EffectBase
{
    [SerializeField] public int HealthValue = 1;

    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        controller.Life += HealthValue;
        yield break;
    }
}