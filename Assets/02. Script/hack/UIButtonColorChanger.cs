using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIButtonColorChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private UnityEngine.UI.Image buttonImage; // 1. Image 이름 충돌 해결
    private Sprite originalSprite;

    [SerializeField]
    private Sprite pressedSprite;

    void Awake()
    {
        buttonImage = GetComponent<UnityEngine.UI.Image>(); // 2. GetComponent<Image>도 수정
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

        // 3. 이벤트 전달 방식 수정
        PassEventTo<IPointerDownHandler>(eventData, ExecuteEvents.pointerDownHandler);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = originalSprite;
        }

        // 4. OnPointerUp 이벤트도 올바르게 전달
        PassEventTo<IPointerUpHandler>(eventData, ExecuteEvents.pointerUpHandler);
    }

    // UI 이벤트를 아래 요소로 전달하는 메서드
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