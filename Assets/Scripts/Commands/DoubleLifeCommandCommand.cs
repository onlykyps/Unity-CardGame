using UnityEngine;

public class DoubleLifeCommandCommand : Command
{
    private int targetID;
    private int amountForEffect;
    private int healthAfter;

    public DoubleLifeCommandCommand(int targetID, int amountForEffect, int healthAfter)
    {
        this.targetID = targetID;
        this.amountForEffect = amountForEffect;
        this.healthAfter = healthAfter;
    }

    public override void StartCommandExecution()
    {
        Debug.Log("In deal double life command!");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);
        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID || targetID == GlobalSettings.Instance.TopPlayer.PlayerID)
        {
            // target is a hero
            target.GetComponent<PlayerPortraitVisual>().GiveLife(amountForEffect, healthAfter);
        }
        //else
        //{
        //    // target is a creature
        //    target.GetComponent<OneCreatureManager>().TakeDamage(amount, healthAfter);
        //}
        CommandExecutionComplete();
    }
}
