using UnityEngine;

public class CatPawController : MonoBehaviour
{
    public RectTransform pawImage;  // ����� �� �̹��� (Inspector�� CatPaw �ڽ� �ֱ�)
    public Canvas canvas;           // ĵ���� (Inspector�� MainCanvas �ֱ�)

    void Update()
    {
        if (pawImage == null || canvas == null) return; // ������ġ

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
