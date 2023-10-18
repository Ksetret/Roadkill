using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomePlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject _blood;

    //public GameObject char_cam;

    float _speed;

    private void Awake()
    {
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            _speed = -0.1f;
        else if (Input.GetKey(KeyCode.D))
            _speed = 0.1f;
        else
            _speed = 0;

        //
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + _speed,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z);

        //print(_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            other.gameObject.SetActive(false);
        }

        //print(other.name);
    }
}
