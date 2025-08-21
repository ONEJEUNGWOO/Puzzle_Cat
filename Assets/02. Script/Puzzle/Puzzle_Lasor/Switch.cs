using UnityEngine;

/// <summary>
/// ����ġ�� ���� ��ֹ��� ���� ����
/// </summary>
public class Switch : MonoBehaviour, LaserPuzzle.IInteractable
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
        obstacle.transform.localPosition = isActive ? new Vector3(obstacle.transform.localPosition.x, 0, obstacle.transform.localPosition.z) :
                                        new Vector3(obstacle.transform.localPosition.x, -0.9f, obstacle.transform.localPosition.z);

        manager = transform.parent.GetComponentInParent<LaserPuzzleManager>();

    }

    public void OnClick()
    {
        ToggleSwitch();
    }

    private void ToggleSwitch()
    {
        isActive = !isActive;
        material.color = isActive ? activatedColor : deactivatedColor;
        obstacle.transform.localPosition = isActive ? new Vector3(obstacle.transform.localPosition.x, 0, obstacle.transform.localPosition.z) :
                                        new Vector3(obstacle.transform.localPosition.x, -0.9f, obstacle.transform.localPosition.z);

        manager.RecalculateLaser();
    }
}
