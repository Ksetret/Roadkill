using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    [SerializeField] private float _timer = 2f;

    private void Start()
    {
        Invoke("DeactivateAfterTime", _timer);
    }

    private void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
