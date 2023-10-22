using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    //[SerializeField] float _zSpeed = 1.5f;

    CharacterAnimation _characterAnimation;
    Rigidbody _rigidbody;

    float _yRotation = 90f;
    //float _rotationSpeed;

    public void DetectMovement(float movement_x, float movement_z = 0)
    {
        _rigidbody.velocity = new Vector3(movement_x * _speed, _rigidbody.velocity.y, movement_z * _speed); // Input.GetAxisRaw(Axis.VERTICAL_AXIS) * _zSpeed;
    }

    public void RotatePlayer(float movement)
    {
        if (movement > 0)
            _yRotation = 90f;
        if (movement < 0)
            _yRotation = -90f;

        transform.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }

    public void AnimatePlayerWalk(float movement)
    {
        _characterAnimation.Walk(movement != 0);
    }



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }
}
