using Game.Common;
using LaserPuzzle;
using UnityEngine;

public class LaserReflecter : RotatableObject, IInteractable, ILaserInteractable
{
    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        Vector3 reflectDir = Vector3.Reflect(laserHitInfo.incomingDirection, laserHitInfo.hitNormal);
        if(raycaster != null)
            raycaster.CastLaser(transform.position, reflectDir, laserHitInfo.laserColor, Constants.LASER_MAX_DISTANCE);
    }
}
