using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] CapsuleCollider _colliderFullHeight;
    [SerializeField] CapsuleCollider _colliderOnCrouch;

    HealthSystem _healthSystem;
    CharacterMovement _characterMovement;
    CharacterAnimation _characterAnimation;

    float _xMovement, _zMovement;

    bool CheckCrouch(bool is_pressed)
    {
        _colliderOnCrouch.enabled = is_pressed;
        _colliderFullHeight.enabled = !is_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.CROUCH_ANIMATION, is_pressed);

        return is_pressed;
    }

    bool CheckBlock(bool is_pressed)
    {
        _healthSystem._inBlockingState = is_pressed;
        _characterAnimation.SetAnimationBoolByName(AnimationTags.BLOCK_ANIMATION, is_pressed);

        return is_pressed;
    }



    void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MainMenu.instance.Pause();

        if (!_healthSystem._isDead)
        {
            _characterAnimation.Move(false);
            _characterMovement.RotatePlayer(_xMovement);

            if(!CheckCrouch(Input.GetKey(KeyCode.LeftControl))
            && !CheckBlock(Input.GetKey(KeyCode.R)))
                if (_xMovement != 0 || _zMovement != 0)
                    _characterAnimation.Move(true);
        }
    }

    void FixedUpdate()
    {
        _xMovement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        _zMovement = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        if(!Input.GetKey(KeyCode.LeftControl)
        && !Input.GetKey(KeyCode.R)
        && !_healthSystem._isDead)
            _characterMovement.DetectMovement(_xMovement, _zMovement);
    }
}
