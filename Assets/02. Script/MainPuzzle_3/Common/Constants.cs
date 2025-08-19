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
    /// ������ �浹 ������ ��� ����ü
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

    [System.Serializable]
    public struct LaserRaycastInfo
    {
        public Vector3 originPos;
        public Vector3 raycastDirection;
        public Color laserColor;
        public float maxDistance;

        public LaserRaycastInfo(Vector3 pos, Vector3 dir, Color color, float dist)
        {
            originPos = pos;
            raycastDirection = dir;
            laserColor = color;
            maxDistance = dist;
        }
    }
}