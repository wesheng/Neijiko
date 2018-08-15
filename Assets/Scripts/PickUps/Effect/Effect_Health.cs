namespace PickUps.Effect
{
    public class Effect_Health : Effect_Base
    {
        private int healthValue;

        public Effect_Health(int healthToGive) : base(0)
        {
            healthValue = healthToGive;
        }

        public override void EffectStart(NejikoController controller)
        {
            controller.Life += healthValue;
        }

        public override void EffectUpdate(NejikoController controller)
        {
            
        }

        public override void EffectEnd(NejikoController controller)
        {
            
        }
    }
}