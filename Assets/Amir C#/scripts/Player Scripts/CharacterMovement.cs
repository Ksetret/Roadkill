using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float _xSpeed = 3f;
    [SerializeField] float _zSpeed = 1.5f;
    [SerializeField] Transform _mesh;

    CharacterAnimation _characterAnimation;
    Rigidbody _rigidbody;

    float _yRotation = 90f;
    //float _rotationSpeed;

    public void DetectMovement(float movement_x = 0, float movement_z = 0)
    {
        Vector3 velocity = new Vector3(movement_x * _xSpeed,
                                      _rigidbody.velocity.y,
                                      movement_z * _zSpeed);

        _rigidbody.velocity = velocity;
    }

    public void RotatePlayer(float movement)
    {
        if (movement > 0)
            _yRotation = 90f;
        if (movement < 0)
            _yRotation = -90f;

        _mesh.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }

    public void AnimatePlayerWalk(bool movement)
    {
        _characterAnimation.Move(movement);
    }



    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }
}
