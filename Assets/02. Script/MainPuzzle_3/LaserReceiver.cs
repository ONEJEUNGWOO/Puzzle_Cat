using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReceiver : MonoBehaviour, LaserPuzzle.ILaserInteractable
{
    public Color color;
    [SerializeField] private bool isActive = false;

    private LaserPuzzleManager manager;
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Material modelMaterial;

    private void Awake()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        targetMaterial = renderers[0].material;
        modelMaterial = renderers[1].material;
    }

    private void Start()
    {
        manager = transform.parent.GetComponentInParent<LaserPuzzleManager>();
        manager.OnObjectChange += ResetState;

        targetMaterial.color = color;
    }

    public void Activate()
    {
        isActive = true;
        modelMaterial.color = color;
        manager.CheckCompletion();
    }

    public void OnLaserHit(Game.Common.LaserHitInfo laserHitInfo)
    {
        if(laserHitInfo.laserColor == color)
        {
            Activate();
        }
    }

    private void ResetState()
    {
        isActive = false;
        modelMaterial.color = Color.white;
    }

    public bool CheckActive() => isActive; 
}
