using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Points")]
public class EffectPoints : EffectBase
{
    [SerializeField] public float score;

    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        GlobalInfo.GameController.score += score;
        yield break;
    }
}