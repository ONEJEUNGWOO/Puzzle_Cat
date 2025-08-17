using UnityEngine;

public class CatPawController : MonoBehaviour
{
    public RectTransform pawImage;  // 고양이 팔 이미지 (Inspector에 CatPaw 자신 넣기)
    public Canvas canvas;           // 캔버스 (Inspector에 MainCanvas 넣기)

    void Update()
    {
        if (pawImage == null || canvas == null) return; // 안전장치

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out localPoint
        );

        pawImage.localPosition = localPoint;
    }
}
