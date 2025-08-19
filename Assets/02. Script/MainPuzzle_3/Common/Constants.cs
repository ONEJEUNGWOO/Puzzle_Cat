using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Common
{
    public static class Constants
    {
        public const float LASER_MAX_DISTANCE = 50f;
        public const float LASER_MAX_WIDTH = 0.2f;
    }

    /// <summary>
    /// 레이저 충돌 정보를 담는 구조체
    /// </summary>
    public struct LaserHitInfo
    {
        public Vector3 hitPoint;
        public Vector3 incomingDirection;
        public Vector3 hitNormal;
        public Color laserColor;

        public LaserHitInfo(Vector3 point, Vector3 dir, Vector3 normal, Color color)
        {
            hitPoint = point;
            incomingDirection = dir;
            hitNormal = normal;
            laserColor = color;
        }
    }

    public struct LaserRaycastInfo
    {
        public Vector3 raycastDirection;
        public Color laserColor;

        public LaserRaycastInfo(Vector3 dir, Color color)
        {
            raycastDirection = dir;
            laserColor = color;
        }
    }
}