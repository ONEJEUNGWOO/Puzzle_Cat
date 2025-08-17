using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIButtonColorChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private UnityEngine.UI.Image buttonImage; // 1. Image �̸� �浹 �ذ�
    private Sprite originalSprite;

    [SerializeField]
    private Sprite pressedSprite;

    void Awake()
    {
        buttonImage = GetComponent<UnityEngine.UI.Image>(); // 2. GetComponent<Image>�� ����
        if (buttonImage != null)
        {
            originalSprite = buttonImage.sprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (buttonImage != null && pressedSprite != null)
        {
            buttonImage.sprite = pressedSprite;
        }

        // 3. �̺�Ʈ ���� ��� ����
        PassEventTo<IPointerDownHandler>(eventData, ExecuteEvents.pointerDownHandler);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = originalSprite;
        }

        // 4. OnPointerUp �̺�Ʈ�� �ùٸ��� ����
        PassEventTo<IPointerUpHandler>(eventData, ExecuteEvents.pointerUpHandler);
    }

    // UI �̺�Ʈ�� �Ʒ� ��ҷ� �����ϴ� �޼���
    private void PassEventTo<T>(PointerEventData eventData, ExecuteEvents.EventFunction<T> handler) where T : IEventSystemHandler
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        GameObject currentGo = eventData.pointerCurrentRaycast.gameObject;

        for (int i = 0; i < results.Count; i++)
        {
            if (currentGo != results[i].gameObject)
            {
                ExecuteEvents.Execute(results[i].gameObject, eventData, handler);
                break;
            }
        }
    }
}