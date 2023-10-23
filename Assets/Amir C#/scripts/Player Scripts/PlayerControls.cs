using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] CapsuleCollider _colliderFullHeight;
    [SerializeField] CapsuleCollider _colliderOnCrouch;

    HealthSystem _healthSystem;
    CharacterMovement _characterMovement;
    CharacterAnimation _characterAnimation;

    float _xMovement, _zMovement;

    bool CheckCrouch(bool is_button_pressed)
    {
        _colliderOnCrouch.enabled = is_button_pressed;
        _colliderFullHeight.enabled = !is_button_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.CROUCH_ANIMATION, is_button_pressed);

        return is_button_pressed;
    }

    bool CheckBlock(bool is_button_pressed)
    {
        _healthSystem._inBlockingState = is_button_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.BLOCK_ANIMATION, is_button_pressed);

        return is_button_pressed;
    }



    void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Update()
    {
        if(!_healthSystem._isDead)
        {
            _characterAnimation.Move(false);
            _characterMovement.RotatePlayer(_xMovement);

            CheckCrouch(Input.GetKey(KeyCode.LeftControl));
            CheckBlock(Input.GetKey(KeyCode.B));
            //
            if (_xMovement != 0 || _zMovement != 0)
                _characterAnimation.Move(true);
        }
    }

    void FixedUpdate()
    {
        _xMovement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        _zMovement = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.B) && !_healthSystem._isDead)
            _characterMovement.DetectMovement(_xMovement, _zMovement);
    }
}
