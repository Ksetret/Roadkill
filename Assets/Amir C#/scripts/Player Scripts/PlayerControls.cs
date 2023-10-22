using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public bool _inBlockingState;

    CharacterMovement _characterMovement;

    float _xMovement, _zMovement;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            transform.localScale = new Vector3(1f, 0.5f, 1f);
        else if (Input.GetKey(KeyCode.B))
            _inBlockingState = Input.GetKey(KeyCode.B);
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

            _characterMovement.RotatePlayer(_xMovement);

            if (_xMovement != 0 || _zMovement != 0)
                _characterMovement.AnimatePlayerWalk(true);
            else
                _characterMovement.AnimatePlayerWalk(false);
        }
    }

    private void FixedUpdate()
    {
        _xMovement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        _zMovement = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        _characterMovement.DetectMovement(_xMovement, _zMovement); // new Vector3(_horizontal, 0, _vertical));
    }
}
