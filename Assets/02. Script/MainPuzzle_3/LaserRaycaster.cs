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
    public int canHitNum = 3; // 최대 반사 횟수
    public int curHitNum = 0; // 현재 반사 횟수

    private LaserPuzzleManager manager;


    private void Awake()
    {
        // Emitter용 라인렌더러
        lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer != null)
            lineRenderer.material = baseMaterial;

        // LaserReflecter & ColorLens용 라인렌더러 컴포넌트들
        lineRenderers = GetComponentsInChildren<LineRenderer>();
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.material = baseMaterial;
        }
    }

    private void Start()
    {
        // 퍼즐 매니저를 찾고 매니저의 이벤트를 구독
        // 이게 정말 하드코딩이란걸 알지만 싱글턴이나 동적생성을 하지 않고 매니저를 찾을 방법 중 가장 빨라서 어쩔 수 없음
        // 이에 관해 고민을 좀 더 해봐야 할 듯
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
    /// 발사해야 할 레이저가 2개 이상일 경우 처리 방법 고민중
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
