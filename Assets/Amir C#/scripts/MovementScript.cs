using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    //[SerializeField] private GameObject _blood;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }

    private void Awake()
    {
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        _surfaceSlider = GetComponent<SurfaceSlider>();
        //
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.A))
            _speed = -0.1f;
        else if (Input.GetKey(KeyCode.D))
            _speed = 0.1f;
        else
            _speed = 0;*/

        //
    }

    private void FixedUpdate()
    {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + _speed,
                                                    //gameObject.transform.position.y,
                                                    //gameObject.transform.position.z);

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