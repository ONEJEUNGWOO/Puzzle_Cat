using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MatrixCell : MonoBehaviour
{
    private int row;
    private int col;
    private BreachProtocolManager manager;

    public UnityEngine.UI.Image myImage;
    private CatItem myItem;

    public void Init(int r, int c, BreachProtocolManager m, List<Sprite> sprites)
    {
        row = r;
        col = c;
        manager = m;

        if (myImage != null && sprites.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, sprites.Count);
            myItem = (CatItem)randomIndex;
            myImage.sprite = sprites[randomIndex];
        }
    }

    public void OnClick()
    {
        manager.CellSelected(row, col, myItem);
    }

    public void SetColor(Color color)
    {
        if (myImage != null)
        {
            myImage.color = color;
        }
    }

    public void SetInteractable(bool isInteractable)
    {
        GetComponent<Button>().interactable = isInteractable;
    }
}