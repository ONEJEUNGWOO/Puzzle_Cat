using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CellState { Normal, Highlighted, Selected, Disabled }

public class GridCell : MonoBehaviour
{
    public int cellRow;  // ���� row ��� ���
    public int cellCol;  // ���� col ��� ���

    public Button button;
    public Image image;
    public TextMeshProUGUI codeText;

    public CellState currentState { get; private set; }

    void Awake()
    {
        if (!button) button = GetComponent<Button>();
        if (!image) image = GetComponent<Image>();
        if (!codeText) codeText = GetComponentInChildren<TextMeshProUGUI>();
        currentState = CellState.Normal;
    }

    public void Setup(string code, int r, int c, UnityEngine.Events.UnityAction onClickAction)
    {
        codeText.text = code;
        cellRow = r;
        cellCol = c;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(onClickAction);
    }

    public void SetState(CellState state, Color color)
    {
        currentState = state;
        image.color = color;
        button.interactable = !(state == CellState.Selected || state == CellState.Disabled);
    }
}
