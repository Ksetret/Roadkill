using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackDistance = 1f;

    private CharacterAnimation _enemyAnim;
    private Rigidbody _myBody;
    [SerializeField] private Transform _playerTarget;
    private float _chasePlayerAfterAttack = 1f;

    private float _currentAttackTime;
    [SerializeField] private float _defaultAttackTime = 2f;
    private bool _followPlayer = false;
    private bool _attackPlayer = false;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _enemyAnim = GetComponentInChildren<CharacterAnimation>();
        _myBody = GetComponent<Rigidbody>();

        _playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        // _followPlayer = true;
        _currentAttackTime = _defaultAttackTime;
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {

        if (!_followPlayer)
            return;

        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance)
        {
            transform.LookAt(_playerTarget);
            //_myBody.velocity = transform.forward * _speed;
            _agent.destination = _playerTarget.position;


            if (_myBody.velocity.sqrMagnitude != 0)
            {
                _enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, _playerTarget.position) <= _attackDistance)
        {
            _myBody.velocity = Vector3.zero;
            _enemyAnim.Walk(false);

            _followPlayer = false;
            _attackPlayer = true;

        }
    }

    private void Attack()
    {
        if (!_attackPlayer || GetComponent<HealthSystem>()._isDead == true)
            return;

        _currentAttackTime += Time.deltaTime;

        if (_currentAttackTime > _defaultAttackTime)
        {
            _enemyAnim.EnemyAttack(UnityEngine.Random.Range(0, 3));
            _currentAttackTime = 0f;
            _currentAttackTime = 0f;
            transform.LookAt(_playerTarget);
        }

        if (Vector3.Distance(transform.position, _playerTarget.position) > _attackDistance + _chasePlayerAfterAttack)
        {
            _attackPlayer = false;
            _followPlayer = true;
        }
    }

    public void StartMap()
    {
        _followPlayer = true;
    }
}
