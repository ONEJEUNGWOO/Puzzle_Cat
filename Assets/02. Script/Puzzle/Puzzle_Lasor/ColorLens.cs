using Game.Common;
using LaserPuzzle;
using UnityEngine;

/// <summary>
/// �÷�����
/// �������� ������ �������� ����������� �÷������ ���� ���� �������� �߻�
/// </summary>
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
            LaserRaycastInfo raycastInfo = new LaserRaycastInfo(transform.position, laserHitInfo.incomingDirection, color, Constants.LASER_MAX_DISTANCE);
            raycaster.AddLaserInfo(raycastInfo);
            raycaster.CastAllLaser();
        }
    }
}
