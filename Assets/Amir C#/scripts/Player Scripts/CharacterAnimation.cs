using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Move(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
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
