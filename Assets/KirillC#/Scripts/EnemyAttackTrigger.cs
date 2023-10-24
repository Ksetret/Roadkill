using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
            if (other.gameObject.tag == "Player")
        _enemy.GetComponent<EnemyMovement>().StartMap();
    }
}
