using UnityEngine;

public class HoldTurnCommand : Command
{
    private int targetID;

    public HoldTurnCommand(int targetID)
    {
        this.targetID = targetID;
    }

    public override void StartCommandExecution()
    {
        Debug.Log("Holding other player one turn");

        GameObject target = IDHolder.GetGameObjectWithID(targetID);

        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID || targetID == GlobalSettings.Instance.TopPlayer.PlayerID)
        {
            // target is a hero
            target.GetComponent<PlayerPortraitVisual>().HoldTurn(targetID);
        }
        CommandExecutionComplete();
    }
}
