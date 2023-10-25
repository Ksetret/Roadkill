using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackDistance = 1f;

    private CharacterAnimation _bossAnim;
    private Rigidbody _myBody;
    private Transform _playerTarget;
    private float _chasePlayerAfterAttack = 1f;

    private float _currentAttackTime;
    private float _defaultAttackTime = 2f;
    private bool _firePlayer = false;
    private bool _attackPlayer = false;

    private AnimationController _animationBoss;

    private void Awake()
    {
        _bossAnim = GetComponentInChildren<CharacterAnimation>();

        _animationBoss = GetComponentInChildren<AnimationController>();

        _myBody = GetComponent<Rigidbody>();

        _playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        _firePlayer = true;
        _currentAttackTime = _defaultAttackTime;
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FireTarget();
    }

    private void FireTarget()
    {
        if (!_firePlayer)
            return;

        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance)
        {
            transform.LookAt(_playerTarget);

            if (_myBody.velocity.sqrMagnitude != 0)
            {
                _animationBoss.Fire(true);
            }
        }
        else if (Vector3.Distance(transform.position, _playerTarget.position) <= _attackDistance)
        {
            _myBody.velocity = Vector3.zero;
            _animationBoss.Fire(false);

            _firePlayer = false;
            _attackPlayer = true;

        }
    }

    private void Attack()
    {
        if (!_attackPlayer)
            return;

        _currentAttackTime += Time.deltaTime;

        if (_currentAttackTime > _defaultAttackTime)
        {
            _bossAnim.EnemyAttack(UnityEngine.Random.Range(0, 3));
            _currentAttackTime = 0f;
        }

        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance + _chasePlayerAfterAttack)
        {
            _attackPlayer = false;
            _firePlayer = true;
        }
    }
}
