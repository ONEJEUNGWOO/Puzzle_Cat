using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FloorController : MonoBehaviour
{
    public int moveSpeed;

    private Vector2 curMovementInput;

    private void FixedUpdate()
    {
        MoveFloor();
    }

    public void OnSetMoveValue(InputAction.CallbackContext context)
    {
        Debug.Log("?");
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("?");
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            Debug.Log("!");
            curMovementInput = Vector2.zero;
        }
    }

    public void MoveFloor()
    {
        transform.Rotate(curMovementInput, moveSpeed * Time.deltaTime);
    }
}
