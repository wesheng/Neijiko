using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Speed")]
public class EffectSpeed : EffectDuration
{
    [SerializeField] public float speed;
    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        controller.speedZ += speed;
        yield return new WaitForSeconds(Duration);
        controller.speedZ -= speed;
    }
}