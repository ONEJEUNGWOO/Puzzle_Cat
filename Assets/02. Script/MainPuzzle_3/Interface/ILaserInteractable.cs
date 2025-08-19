using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LaserPuzzle
{
    public interface ILaserInteractable
    {
        void OnLaserHit(Game.Common.LaserHitInfo laserHitInfo);
    }
}