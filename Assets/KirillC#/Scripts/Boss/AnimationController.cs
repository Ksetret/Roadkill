using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _bossAnimator;

    private void Start()
    {
        _bossAnimator = GetComponent<Animator>();
    }

    public void Fire(bool idle)
    {
        _bossAnimator.SetBool("Idle", idle);
    }

    public void Hit()
    {
        _bossAnimator.SetTrigger("Hit");
    }

    public void Punch1()
    {
        _bossAnimator.SetTrigger("Punch1");
    }
    public void Punch2()
    {
        _bossAnimator.SetTrigger("Punch2");
    }

    public void Dead()
    {
        _bossAnimator.SetTrigger("Dead");
    }

}
