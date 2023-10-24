using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    private CharacterAnimation _animationScript;
    private EnemyMovement __enemyMovement;
    private bool _characterDied;

    [SerializeField] private bool _isPlayer;
    [SerializeField] private float _health = 100f;


    private void Awake()
    {
        _animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (_characterDied)
            return;

        _health -= damage;

        if(_health <= 0f)
        {
            //_animationScript.Death();
            _characterDied = true;

            if (_isPlayer)
            {

            }
            return;
        }

        if (!_isPlayer)
        {
            if (knockDown)
            {
                if(Random.Range(0, 2) > 0)
                {
                    //_animationScript.KnockDown();
                }
                else
                {
                    if(Random.Range(0, 3) > 1)
                    {
                        //_animationScript.Hit();
                    }
                }

            }
        }
    }

}
