using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _healthBarRobot;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
            if (other.gameObject.tag == "Player")
        _enemy.GetComponent<EnemyMovement>().StartMap();

            if(_healthBarRobot != null)
            _healthBarRobot.SetActive(true);
       // GetComponent<BoxCollider>().isTrigger = false;

         //   Destroy(gameObject);
    }

}
