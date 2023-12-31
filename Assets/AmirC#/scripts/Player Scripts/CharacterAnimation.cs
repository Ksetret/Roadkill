using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private bool _deaed;

    public void Move(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
    }
    public void Block(bool move)
    {
        _animator.SetBool(AnimationTags.BLOCK_ANIMATION, move);
    }

    public void Hit()
    {
        _animator.SetTrigger(AnimationTags.HIT_TRIGGER);
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationTags.DEATH_TRIGGER);
        transform.GetComponentInParent<CapsuleCollider>().enabled = false;
        transform.GetComponentInParent<Rigidbody>().useGravity = false;
        Destroy(gameObject, 3f);

    }

    public void SetAnimationBoolByName(string bool_name, bool state)
    {
        _animator.SetBool(bool_name, state);
    }

    public void SetAnimationTriggerByName(string trigger_name)
    {
        _animator.SetTrigger(trigger_name);
    }

    public void EnemyAttack(int attack)
    {
        if (attack == 0)
            _animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
        if (attack == 1)
            _animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
        if (attack == 2)
            _animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    } // enemy atack

    public void Walk(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Fire(bool fire)
    {
        _animator.SetBool("Fire", fire);
    }
}
