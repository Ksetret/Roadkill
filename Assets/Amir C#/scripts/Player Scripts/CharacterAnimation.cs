using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Move(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
    }

    public void Hit()
    {
        _animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
    }

    public void SetAnimationBoolByName(string bool_name, bool state)
    {
        _animator.SetBool(bool_name, state);
    }

    public void SetAnimationTriggerByName(string trigger_name)
    {
        _animator.SetTrigger(trigger_name);
    }



    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
