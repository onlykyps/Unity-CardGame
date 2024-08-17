public class HoldTurn : SpellEffect
{
    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        new HoldTurnCommand(target.ID).AddToQueue();
    }
}
