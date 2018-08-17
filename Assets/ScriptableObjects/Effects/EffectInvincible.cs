using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Invincible")]
public class EffectInvincible : EffectDuration
{
    public override IEnumerator EffectCoroutine(NejikoController controller)
    {
        var   renderer            = controller.GetComponentInChildren<Renderer>();
        float timeLeft            = Duration;
        var   characterController = controller.GetComponent<CharacterController>();
        characterController.detectCollisions = false;
        int roboLayer = LayerMask.NameToLayer("Robo");
        Physics.IgnoreLayerCollision(characterController.gameObject.layer, roboLayer, true);
        bool isShowing = false;
        while (timeLeft >= 0)
        {
            renderer.enabled = isShowing;
            isShowing        = !isShowing;

            timeLeft -= Time.deltaTime;
            yield return null;
        }

        Physics.IgnoreLayerCollision(characterController.gameObject.layer, roboLayer, false);
        characterController.detectCollisions = true;
        renderer.enabled                     = true;
    }
}
