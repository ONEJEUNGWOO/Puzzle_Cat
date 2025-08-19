using Game.Common;
using LaserPuzzle;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class LaserRaycaster : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Material baseMaterial;

    [SerializeField] private LineRenderer[] lineRenderers;
    [SerializeField] public List<LaserRaycastInfo> laserRaycastInfos = new List<LaserRaycastInfo>();

    public bool isRayCasting = false;
    public int canHitNum = 3; // �ִ� �ݻ� Ƚ��
    public int curHitNum = 0; // ���� �ݻ� Ƚ��

    private LaserPuzzleManager manager;


    private void Awake()
    {
        // Emitter�� ���η�����
        lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer != null)
            lineRenderer.material = baseMaterial;

        // LaserReflecter & ColorLens�� ���η����� ������Ʈ��
        lineRenderers = GetComponentsInChildren<LineRenderer>();
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.material = baseMaterial;
        }
    }

    private void Start()
    {
        // ���� �Ŵ����� ã�� �Ŵ����� �̺�Ʈ�� ����
        // �̰� ���� �ϵ��ڵ��̶��� ������ �̱����̳� ���������� ���� �ʰ� �Ŵ����� ã�� ��� �� ���� ���� ��¿ �� ����
        // �̿� ���� ����� �� �� �غ��� �� ��
        manager = transform.parent.GetComponentInParent<LaserPuzzleManager>();
        manager.OnObjectChange += ClearAllLaserInfo;
    }

    public void CastLaser(Vector3 origin, Vector3 direction, Color color, float maxDistance)
    {
        //if (isRayCasting) return;
        //isRayCasting = true;

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, origin);
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = Constants.LASER_MAX_WIDTH;
        lineRenderer.endWidth = Constants.LASER_MAX_WIDTH;

        Vector3 currentPos = origin;
        Vector3 currentDir = direction;

        if (Physics.Raycast(currentPos, currentDir, out RaycastHit hit, maxDistance))
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

            ILaserInteractable interactable = hit.collider.transform.parent.GetComponent<ILaserInteractable>();
            if (interactable != null)
            {
                interactable.OnLaserHit(new LaserHitInfo(hit.point, currentDir, hit.normal, color));
            }
        }
        else
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPos + currentDir * maxDistance);
        }
    }

    public void ClearLaser()
    {
        lineRenderer.positionCount = 0;
        isRayCasting = false;
    }

    /// <summary>
    /// �߻��ؾ� �� �������� 2�� �̻��� ��� ó�� ��� �����
    /// </summary>
    public void CastAllLaser()
    {
        ClearAllLaser();
        if(lineRenderers.Length >= laserRaycastInfos.Count)
        {
            for(int i = 0; i < laserRaycastInfos.Count; i++)
            {
                if (curHitNum > canHitNum+1) return;
                lineRenderers[i].positionCount = 1;
                lineRenderers[i].SetPosition(0, laserRaycastInfos[i].originPos);
                lineRenderers[i].startColor = laserRaycastInfos[i].laserColor;
                lineRenderers[i].endColor = laserRaycastInfos[i].laserColor;
                lineRenderers[i].startWidth = Constants.LASER_MAX_WIDTH;
                lineRenderers[i].endWidth = Constants.LASER_MAX_WIDTH;

                Vector3 currentPos = laserRaycastInfos[i].originPos;
                Vector3 currentDir = laserRaycastInfos[i].raycastDirection;

                curHitNum++;

                if (Physics.Raycast(currentPos, currentDir, out RaycastHit hit, laserRaycastInfos[i].maxDistance))
                {
                    lineRenderers[i].positionCount++;
                    lineRenderers[i].SetPosition(lineRenderers[i].positionCount - 1, hit.point);

                    ILaserInteractable interactable = hit.collider.transform.parent.GetComponent<ILaserInteractable>();
                    if (interactable != null)
                    {
                        interactable.OnLaserHit(new LaserHitInfo(hit.point, currentDir, hit.normal, laserRaycastInfos[i].laserColor));
                    }
                }
                else
                {
                    lineRenderers[i].positionCount++;
                    lineRenderers[i].SetPosition(lineRenderers[i].positionCount - 1, currentPos + currentDir * laserRaycastInfos[i].maxDistance);
                }
            }
        }
    }

    public void ClearAllLaser()
    {
        foreach (LineRenderer line in lineRenderers)
        {
            line.positionCount = 0;
        }
    }

    public void ClearAllLaserInfo()
    {
        ClearAllLaser();
        curHitNum = 0;
        laserRaycastInfos.Clear();
    }

    public void AddLaserInfo(LaserRaycastInfo info)
    {
        if (laserRaycastInfos.Contains(info))
            return;
        else
            laserRaycastInfos.Add(info);
    }
}
