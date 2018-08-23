using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Speed")]
public class EffectSpeed : EffectDuration
{
    [SerializeField] public bool UseAsMultiplier;
    [SerializeField] public float Speed;
    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        float speedToAdd = UseAsMultiplier ?
            controller.speedZ * Speed - controller.speedZ : Speed;
        controller.speedZ += speedToAdd;
        yield return new WaitForSeconds(Duration);
        controller.speedZ -= speedToAdd;
    }
}