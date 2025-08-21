using Game.Common;
using UnityEngine;

/// <summary>
/// �������� �����ϸ� ��ֹ��� �����ϴ� �Լ�
/// ���� ��ȹ�� �������� ������ ���� ����������, �� ��� ���ѹݺ��� �߻��Ͽ� �� �� �����ϸ� �����Ǵ� ������ ����
/// </summary>
public class Sensor : MonoBehaviour, LaserPuzzle.ILaserInteractable
{
    public Color targetColor;

    public Material material;
    public GameObject obstacle;

    public bool isActive = false;

    private LaserPuzzleManager manager;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        material.color = targetColor;

        obstacle = transform.parent.GetChild(1).gameObject;

        manager = transform.parent.GetComponentInParent<LaserPuzzleManager>();
        //manager.OnObjectChange += ResetState;
    }

    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        if (isActive) return;
        if(targetColor == laserHitInfo.laserColor)
        {
            obstacle.transform.localPosition = new Vector3(obstacle.transform.localPosition.x, -0.9f, obstacle.transform.localPosition.z);
            isActive = true;
            manager.RecalculateLaser();
        }
    }

    private void ResetState()
    {
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, 0, obstacle.transform.position.z);
        isActive = true;
    }
}
