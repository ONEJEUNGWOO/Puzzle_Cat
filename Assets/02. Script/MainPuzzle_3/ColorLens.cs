using Game.Common;
using LaserPuzzle;
using UnityEngine;

public class ColorLens : MonoBehaviour, ILaserInteractable
{
    [SerializeField] private Color color;

    private LaserRaycaster raycaster;
    private Material material;

    private void Awake()
    {
        raycaster = GetComponent<LaserRaycaster>();
        material = transform.GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start()
    {
        color.a = 1f;
        material.color = color;
    }

    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        if(raycaster != null)
        {
            raycaster.CastLaser(transform.position, laserHitInfo.incomingDirection, color, Constants.LASER_MAX_DISTANCE);
        }
    }
}
