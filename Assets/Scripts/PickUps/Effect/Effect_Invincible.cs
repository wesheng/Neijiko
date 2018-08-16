using System;
using System.Collections;
using UnityEngine;

namespace PickUps.Effect
{
    public class Effect_Invincible : Effect_Base
    {
        [SerializeField] private Renderer renderer;

        public Effect_Invincible(Renderer renderer, float duration) : base(duration)
        {
            this.renderer = renderer;
        }

        public override void EffectStart(NejikoController controller)
        {
        }

        public override void EffectUpdate(NejikoController controller)
        {
        }

        public override void EffectEnd(NejikoController controller)
        {
        }

        public override IEnumerator EffectCoroutine(NejikoController controller)
        {
            float timeLeft = this.remainingTime;
            var characterController = controller.GetComponent<CharacterController>();
            characterController.detectCollisions = false;
            int roboLayer = LayerMask.NameToLayer("Robo");
            Physics.IgnoreLayerCollision(characterController.gameObject.layer, roboLayer, true);
            bool isShowing = false;
            while (timeLeft >= 0)
            {
                renderer.enabled = isShowing;
                isShowing = !isShowing;

                timeLeft -= Time.deltaTime;
                yield return null;
            }

            Debug.Log("end stop collide");
            Physics.IgnoreLayerCollision(characterController.gameObject.layer, roboLayer, false);
            characterController.detectCollisions = true;
            renderer.enabled = true;

        }
    }
}