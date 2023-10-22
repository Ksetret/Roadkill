using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    CharacterMovement _characterMovement;

    float _movementX;
    private float _movementZ;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        _characterMovement.RotatePlayer(_movementZ);
        _characterMovement.AnimatePlayerWalk(_movementX, _movementZ);
    }

    private void FixedUpdate()
    {
        _movementZ = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        _movementX = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        _characterMovement.DetectMovement(-_movementX, _movementZ); // new Vector3(_horizontal, 0, _vertical));
    }
}
