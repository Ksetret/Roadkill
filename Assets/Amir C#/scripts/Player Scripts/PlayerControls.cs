using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] CapsuleCollider _colliderFullHeight;
    [SerializeField] CapsuleCollider _colliderOnCrouch;

    HealthSystem _healthSystem;
    CharacterMovement _characterMovement;

    float _xMovement, _zMovement;

    private void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if(!_healthSystem._isDead)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _colliderOnCrouch.enabled = true;
                _colliderFullHeight.enabled = false;
            }
            else if (Input.GetKey(KeyCode.B))
                _healthSystem._inBlockingState = Input.GetKey(KeyCode.B);
            else
            {
                _colliderFullHeight.enabled = true;
                _colliderOnCrouch.enabled = false;

                if (_xMovement != 0 || _zMovement != 0)
                    _characterMovement.AnimatePlayerWalk(true);
                else
                    _characterMovement.AnimatePlayerWalk(false);
            }

            _characterMovement.RotatePlayer(_xMovement);
        }
    }

    private void FixedUpdate()
    {
        _xMovement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        _zMovement = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.B) && !_healthSystem._isDead)
            _characterMovement.DetectMovement(_xMovement, _zMovement); // new Vector3(_horizontal, 0, _vertical));
    }
}
