using Game.Common;
using LaserPuzzle;
using UnityEngine;

public class Sensor : MonoBehaviour, ILaserInteractable
{
    public Color targetColor;

    public Material material;
    public GameObject obstacle;

    private LaserPuzzleManager manager;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        material.color = targetColor;

        obstacle = transform.parent.GetChild(1).gameObject;

        manager = transform.parent.GetComponentInParent<LaserPuzzleManager>();
        manager.OnObjectChange += ResetState;
    }

    public void OnLaserHit(LaserHitInfo laserHitInfo)
    {
        if(targetColor == laserHitInfo.laserColor)
        {
            obstacle.transform.position = new Vector3(obstacle.transform.position.x, -0.9f, obstacle.transform.position.z);
            manager.RecalculateLaser();
        }
    }

    private void ResetState()
    {
        obstacle.transform.position = new Vector3(obstacle.transform.position.x, 0, obstacle.transform.position.z);
    }
}
