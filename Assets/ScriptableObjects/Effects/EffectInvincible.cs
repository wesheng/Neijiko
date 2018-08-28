using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Invincible")]
public class EffectInvincible : EffectDuration
{
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private bool ShouldFlash;
    [SerializeField] private Gradient Color;

    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        var   renderer            = controller.GetComponentInChildren<Renderer>();
        float timeLeft            = Duration;
        int enemyLayer = (int) Mathf.Log(EnemyLayer.value, 2);
        Physics.IgnoreLayerCollision(controller.gameObject.layer, enemyLayer, true);
        bool isShowing = false;
        Color originalColor = renderer.material.color;

        while (timeLeft >= 0)
        {
            if (ShouldFlash)
                renderer.enabled = isShowing;
            
            //renderer.material.color = isShowing ? Color.red : originalColor;
            renderer.material.color = Color.Evaluate(timeLeft / Duration);

            isShowing        = !isShowing;

            timeLeft -= Time.deltaTime;
            yield return null;
        }

        renderer.material.color = originalColor;
        Physics.IgnoreLayerCollision(controller.gameObject.layer, enemyLayer, false);
        renderer.enabled                     = true;
    }
}
