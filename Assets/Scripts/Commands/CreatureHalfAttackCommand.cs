using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHalfAttackCommand : Command
{
    private int targetID;

    public CreatureHalfAttackCommand(int targetID)
    {
        this.targetID = targetID;
    }

    public override void StartCommandExecution()
    {
        Debug.Log("Halving other player's creature attacks for 3 turns");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);

        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID || targetID == GlobalSettings.Instance.TopPlayer.PlayerID)
        {
            target.GetComponent<PlayerPortraitVisual>().HalfCreatureAttack(targetID);
        }
        CommandExecutionComplete();
    }
}
