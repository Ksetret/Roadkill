using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instanse;

    [SerializeField] private GameObject _enemyPrefab;

    private void Awake()
    {
        if (instanse == null)
            instanse = this;
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
    }
}
