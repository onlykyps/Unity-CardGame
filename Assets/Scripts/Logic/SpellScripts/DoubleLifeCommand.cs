public class DoubleLifeCommand : SpellEffect
{
    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        //specialAmount = 30 - target.Health;
        int amountForEffect = 30 - target.Health;
        if (amountForEffect == 0)
        {
            int healthAfter = 30;
            new DoubleLifeCommandCommand(target.ID, amountForEffect, healthAfter).AddToQueue();
        }
        else
        {
            if (target.Health * 2 < 30)
            {
                amountForEffect = target.Health;
                new DoubleLifeCommandCommand(target.ID, amountForEffect, healthAfter: target.Health * 2).AddToQueue();
            }
            else
            {
                int healthAfter = 30;
                new DoubleLifeCommandCommand(target.ID, amountForEffect, healthAfter).AddToQueue();
            }
        }

        //target.Health += specialAmount;
    }

    //public override void ActivateEffect(int currentLife, ICharacter target = null)
    //{
    //    TurnManager.Instance.whoseTurn.GetSDLifeBonus();
    //    new DealDamageCommand(target.ID, currentLife, target.Health).AddToQueue();

    //}
}
