using System.Runtime.CompilerServices;

using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour

{

    private InputAction jumpAction;

    private InputAction moveAction;

    public Vector2 inputMove = Vector2.zero;

    public bool isJumpTrigger = false;

    private void Start()

    {

        jumpAction = InputSystem.actions.FindAction("jump");

        moveAction = InputSystem.actions.FindAction("move");

    }

    private void Update()

    {

        inputMove = moveAction.ReadValue<Vector2>();

        if (jumpAction.triggered)

        {

            isJumpTrigger = true;

        }
        else

        {

            isJumpTrigger = false;

        }

    }

}
