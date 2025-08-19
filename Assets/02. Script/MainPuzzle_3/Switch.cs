using LaserPuzzle;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public bool isActive = false;
    public Color activatedColor = Color.red;
    public Color deactivatedColor = Color.gray;

    public Material material;
    public GameObject obstacle;

    private LaserPuzzleManager manager;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        material.color = isActive ? activatedColor : deactivatedColor;

        obstacle = transform.parent.GetChild(1).gameObject;
        obstacle.transform.position = isActive ? new Vector3(obstacle.transform.position.x, 0, obstacle.transform.position.z) :
                                        new Vector3(obstacle.transform.position.x, -1f, obstacle.transform.position.z);

        manager = transform.parent.parent.GetComponent<LaserPuzzleManager>();

    }

    public void OnClick()
    {
        ToggleSwitch();
    }

    private void ToggleSwitch()
    {
        isActive = !isActive;
        material.color = isActive ? activatedColor : deactivatedColor;
        obstacle.transform.position = isActive ? new Vector3(obstacle.transform.position.x, 0, obstacle.transform.position.z) : 
                                                new Vector3(obstacle.transform.position.x, -0.9f, obstacle.transform.position.z);

        manager.RecalculateLaser();
    }
}
