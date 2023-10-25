using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    [SerializeField] private LayerMask _collisiionLayer;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _damage = 2f;

    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isEnemy;

    [SerializeField] private GameObject _hit_FX;

    private void Update()
    {
        DetectCollision();

    }

    private void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radius, _collisiionLayer);
    }
}
