using UnityEngine;

namespace LaserPuzzle
{
    /// <summary>
    /// �������� ��ȣ�ۿ��� �����ϰ� �ϴ� �������̽�
    /// </summary>
    public interface ILaserInteractable
    {
        void OnLaserHit(Game.Common.LaserHitInfo laserHitInfo);
    }
}