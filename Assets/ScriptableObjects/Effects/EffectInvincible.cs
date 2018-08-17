using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Invincible")]
public class EffectInvincible : EffectDuration
{
    [SerializeField] private LayerMask EnemyLayer;

    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        var   renderer            = controller.GetComponentInChildren<Renderer>();
        float timeLeft            = Duration;
        var   characterController = controller.GetComponent<CharacterController>();
        characterController.detectCollisions = false;
        int enemyLayer = (int) Mathf.Log(EnemyLayer.value, 2);
        Physics.IgnoreLayerCollision(characterController.gameObject.layer, enemyLayer, true);
        bool isShowing = false;
        while (timeLeft >= 0)
        {
            renderer.enabled = isShowing;
            isShowing        = !isShowing;

            timeLeft -= Time.deltaTime;
            yield return null;
        }

        Physics.IgnoreLayerCollision(characterController.gameObject.layer, enemyLayer, false);
        characterController.detectCollisions = true;
        renderer.enabled                     = true;
    }
}
