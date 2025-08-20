using Game.Common;
using LaserPuzzle;
using UnityEngine;

public class LaserReflecter : RotatableObject, IInteractable, ILaserInteractable
{
    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        // 반사되는 벡터 계산
        Vector3 reflectDir = Vector3.Reflect(laserHitInfo.incomingDirection, laserHitInfo.hitNormal);
        //if(raycaster != null)
        //    raycaster.CastLaser(transform.position, reflectDir, laserHitInfo.laserColor, Constants.LASER_MAX_DISTANCE);

        float dot = Vector3.Dot(reflectDir, laserHitInfo.incomingDirection);
        // 반사 벡터가 원 벡터와 평행하면 종료
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
