using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSphere : MonoBehaviour
{
    [SerializeField] private uint _hill = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthSystem>())
        {
            other.GetComponent<HealthSystem>().GetHealth(_hill);
            Destroy(gameObject);
        }
    }
}
