using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureHalfAttack : SpellEffect
{
    public override void ActivateEffect(int specialAmount = 0, ICharacter target = null)
    {
        new CreatureHalfAttackCommand(target.ID).AddToQueue();
    }
}

