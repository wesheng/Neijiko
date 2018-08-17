using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Speed")]
public class EffectSpeed : EffectDuration
{
    [SerializeField] public float Speed;
    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        controller.speedZ += Speed;
        yield return new WaitForSeconds(Duration);
        controller.speedZ -= Speed;
    }
}