using UnityEngine;
public class PowerUp : MonoBehaviour
{
    [SerializeField] private EffectBase effect;

    public void GiveEffect(NejikoController controller)
    {
        controller.AddEffect(effect);
    }
}
