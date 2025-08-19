using Game.Common;
using LaserPuzzle;
using UnityEngine;

public class LaserReflecter : RotatableObject, IInteractable, ILaserInteractable
{
    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        Vector3 reflectDir = Vector3.Reflect(laserHitInfo.incomingDirection, laserHitInfo.hitNormal);
        //if(raycaster != null)
        //    raycaster.CastLaser(transform.position, reflectDir, laserHitInfo.laserColor, Constants.LASER_MAX_DISTANCE);

        float dot = Vector3.Dot(reflectDir, laserHitInfo.incomingDirection);
        if (dot <= -1f || dot == 0)
            return;

        if(raycaster != null)
        {
            LaserRaycastInfo raycastInfo = new LaserRaycastInfo(transform.position, reflectDir, laserHitInfo.laserColor, Constants.LASER_MAX_DISTANCE);
            raycaster.AddLaserInfo(raycastInfo);
            raycaster.CastAllLaser();
        }
    }
}
