using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CatItem
{
    Mouse,
    FishingRod,
    Churu,
    Catnip,
    Yarn
}

public class BreachProtocolManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform matrixParent;
    public int rows = 4;
    public int cols = 5;
    public GridLayoutGroup gridLayoutGroup;
    public List<Sprite> itemSprites;
    public List<CatItem> demonSequence;

    private bool isHorizontalTurn = false;
    private int lastClickedRow;
    private int lastClickedCol;
    private int currentSequenceIndex = 0;

    private List<MatrixCell> allCells;

    public Color normalColor = Color.white;
    public Color highlightColor = new Color(0.5f, 1f, 1f, 1f);
    public Color selectedColor = Color.gray;

    private void Start()
    {
        if (gridLayoutGroup != null)
        {
            gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            gridLayoutGroup.constraintCount = cols;
        }

        GenerateMatrix();
        UpdateCellVisuals();
    }

    void GenerateMatrix()
    {
        allCells = new List<MatrixCell>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                GameObject newCell = Instantiate(cellPrefab, matrixParent);
                MatrixCell matrixCell = newCell.GetComponent<MatrixCell>();
                matrixCell.Init(r, c, this, itemSprites);
                allCells.Add(matrixCell);
            }
        }
    }

    public void CellSelected(int r, int c, CatItem clickedItem)
    {
        bool isValidClick = false;

        if (currentSequenceIndex == 0)
        {
            isValidClick = true;
        }
        else if (isHorizontalTurn && r == lastClickedRow)
        {
            isValidClick = true;
        }
        else if (!isHorizontalTurn && c == lastClickedCol)
        {
            isValidClick = true;
        }

        if (isValidClick)
        {
            if (currentSequenceIndex < demonSequence.Count && clickedItem == demonSequence[currentSequenceIndex])
            {
                lastClickedRow = r;
                lastClickedCol = c;
                currentSequenceIndex++;
                isHorizontalTurn = !isHorizontalTurn;

                if (currentSequenceIndex >= demonSequence.Count)
                {
                    Debug.Log("Breach Protocol Success!");
                }
            }
            else
            {
                Debug.Log("Wrong item!");
                ResetGame();
            }
        }
        else
        {
            Debug.Log("Wrong line selected!");
            ResetGame();
        }

        UpdateCellVisuals();
    }

    void UpdateCellVisuals()
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                MatrixCell cell = GetCell(r, c);
                cell.SetColor(normalColor);
                cell.SetInteractable(true);
            }
        }

        if (currentSequenceIndex == 0)
        {
            return;
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                MatrixCell cell = GetCell(r, c);

                if (r == lastClickedRow && c == lastClickedCol)
                {
                    cell.SetColor(selectedColor);
                    cell.SetInteractable(false);
                    continue;
                }

                if (isHorizontalTurn)
                {
                    if (r != lastClickedRow)
                    {
                        cell.SetInteractable(false);
                    }
                }
                else
                {
                    if (c != lastClickedCol)
                    {
                        cell.SetInteractable(false);
                    }
                }

                if ((isHorizontalTurn && r == lastClickedRow) || (!isHorizontalTurn && c == lastClickedCol))
                {
                    cell.SetColor(highlightColor);
                }
            }
        }
    }

    MatrixCell GetCell(int r, int c)
    {
        return allCells[r * cols + c];
    }

    void ResetGame()
    {
        currentSequenceIndex = 0;
        isHorizontalTurn = false;
        Debug.Log("Game Reset.");
        UpdateCellVisuals();
    }
}