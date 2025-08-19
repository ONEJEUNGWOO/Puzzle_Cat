using Game.Common;
using LaserPuzzle;
using Unity.VisualScripting;
using UnityEngine;

public class LaserRaycaster : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Material baseMaterial;

    public bool isRayCasting = false;

    private LaserPuzzleManager manager;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer == null)
        {
            lineRenderer =  transform.AddComponent<LineRenderer>();
        }
        lineRenderer.material = baseMaterial;
    }

    private void Start()
    {
        // 퍼즐 매니저를 찾고 매니저의 이벤트를 구독
        manager = transform.parent.GetComponent<LaserPuzzleManager>();
        manager.OnObjectChange += ClearLaser;
    }

    public void CastLaser(Vector3 origin, Vector3 direction, Color color, float maxDistance)
    {
        if (isRayCasting) return;
        isRayCasting = true;

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

    }
}
