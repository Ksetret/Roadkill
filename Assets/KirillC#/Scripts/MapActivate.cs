using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActivate : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemysArray;
    [SerializeField] private GameObject _nextMap;

    private void OnTriggerExit(Collider other)
    {
      
        if (other.gameObject.tag == "Player")
        {
            
            foreach(GameObject enemy in _enemysArray)
            {
                enemy.GetComponent<EnemyMovement>().StartMap();
            }

            GetComponent<BoxCollider>().isTrigger = false;
            _nextMap.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    
}
