using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _offset;
    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + _offset, transform.position.y, transform.position.z);
    }
}
