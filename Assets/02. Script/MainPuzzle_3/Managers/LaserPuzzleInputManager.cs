using LaserPuzzle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserPuzzleInputManager : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
        ActiveInput();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Vector2 point = input.actions["Point"].ReadValue<Vector2>();
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;

            Physics.Raycast(ray, out hit);
            if(hit.collider != null)
            {
                IInteractable interactable = hit.collider.transform.parent.GetComponent<IInteractable>();
                interactable?.OnClick();
            }
        }
    }

    public void ActiveInput()
    {
        input.ActivateInput();
    }

    public void DeactiveInput()
    {
        input.DeactivateInput();
    }
}
