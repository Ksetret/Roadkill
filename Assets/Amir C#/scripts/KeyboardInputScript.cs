using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class KeyboardInputScript : MonoBehaviour
{
    private PhysicsMovement _movement;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        _movement.Move(new Vector3(horizontal, 0, vertical));
    }
}
