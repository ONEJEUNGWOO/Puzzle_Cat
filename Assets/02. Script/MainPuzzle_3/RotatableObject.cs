using UnityEngine;
using LaserPuzzle;
using System.Collections;

public class RotatableObject : MonoBehaviour, IInteractable
{
    protected LaserPuzzleManager manager;

    protected bool canInteract = true;
    protected LaserRaycaster raycaster;

    private void Awake()
    {
        raycaster = GetComponent<LaserRaycaster>();
    }

    private void Start()
    {
        manager = transform.parent.GetComponent<LaserPuzzleManager>();
    }

    public virtual void OnClick()
    {
        if (canInteract)
        {
            // 회전 동기화 문제 있음
            transform.Rotate(new Vector3(0f, 90f, 0f));
            //Physics.SyncTransforms();
            //manager.RecalculateLaser();
            manager.RecalculateLaser();
        }
    }

}
