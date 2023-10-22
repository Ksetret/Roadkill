using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    CharacterMovement _characterMovement;

    float _movement;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        _characterMovement.RotatePlayer(_movement);
        _characterMovement.AnimatePlayerWalk(_movement);
    }

    private void FixedUpdate()
    {
        _movement = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);

        _characterMovement.DetectMovement(_movement); // new Vector3(_horizontal, 0, _vertical));
    }
}
