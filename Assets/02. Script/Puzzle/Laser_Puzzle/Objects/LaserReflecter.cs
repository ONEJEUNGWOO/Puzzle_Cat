using Game.Common;
using UnityEngine;

/// <summary>
/// ������ �ݻ� ��ġ
/// ���� �������� �ݻ� ���Ͱ� ���� ���Ϳ� �����ϸ� ó������ ����
/// </summary>
public class LaserReflecter : RotatableObject, LaserPuzzle.IInteractable, LaserPuzzle.ILaserInteractable
{
    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        // �ݻ�Ǵ� ���� ���
        Vector3 reflectDir = Vector3.Reflect(laserHitInfo.incomingDirection, laserHitInfo.hitNormal);

        float dot = Vector3.Dot(reflectDir, laserHitInfo.incomingDirection);
        // �ݻ� ���Ͱ� �� ���Ϳ� �����ϸ� ����
        if (Mathf.Abs(dot) > 0.999f)
            return;

        if(raycaster != null)
        {
            LaserRaycastInfo raycastInfo = new LaserRaycastInfo(transform.position, reflectDir, laserHitInfo.laserColor, Constants.LASER_MAX_DISTANCE);
            raycaster.AddLaserInfo(raycastInfo);
            raycaster.CastAllLaser();
        }
    }
}
