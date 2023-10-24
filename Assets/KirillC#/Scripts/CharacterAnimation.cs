using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            //_animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
        }
        if (attack == 1)
        {
            //_animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
        }
        if (attack == 2)
        {
            //_animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
        }
    } // enemy atack
}
