using LaserPuzzle;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������ ������ �Է¿� ���� �Ŵ���
/// ������ ���ÿ� �Է��� Ȱ��ȭ
/// ���� Ŭ���� �ϸ� ��Ȱ��ȭ�� ȣ��(�׷��� ������ ���ŵǸ鼭 �������?)
/// </summary>
public class LaserPuzzleInputManager : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        input = GetComponent<PlayerInput>();
        ActivateInput();
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

    public void ActivateInput()
    {
        input.ActivateInput();
    }

    public void DeactivateInput()
    {
        input.DeactivateInput();
    }
}
