using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    //[SerializeField] float _zSpeed = 1.5f;

    CharacterAnimation _characterAnimation;
    Rigidbody _rigidbody;

    float _yRotation = 90f;
    float _movement;
    //float _rotationSpeed;

    void DetectMovement()
    {
        _rigidbody.velocity = new Vector3(_movement * _speed, _rigidbody.velocity.y, 0); //Input.GetAxisRaw(Axis.VERTICAL_AXIS) * _zSpeed
    }

    void RotatePlayer()
    {
        if (_movement > 0)
            _yRotation = 90f;
        if (_movement < 0)
            _yRotation = -90f;

        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }

    void AnimatePlayerWalk()
    {
        _characterAnimation.Walk(_movement != 0);
    }



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }

    void FixedUpdate()
    {
        _movement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);

        DetectMovement();
    }
}
