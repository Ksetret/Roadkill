using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    [SerializeField] private Animator _animator;

    public void Walk(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Punch_1()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }

    public void Punch_2()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }

    public void Punch_3()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }

    public void Kick_1()
    {
        _animator.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2()
    {
        _animator.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    public void EnemyAttack(int attack)
    {
        if (attack == 0)
        {
            _animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
        }
        if (attack == 1)
        {
            _animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
        }
        if (attack == 2)
        {
            _animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
        }
    } // enemy atack

    public void Play_IdleAnimation()
    {
        _animator.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        _animator.SetTrigger(AnimationTags.KNOCK_DOWN_TRIGGER);
    }

    public void StandUp()
    {
        _animator.SetTrigger(AnimationTags.STAND_UP_TRIGGER);
    }

    public void Hit()
    {
        _animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

}
