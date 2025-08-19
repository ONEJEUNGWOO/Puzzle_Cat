using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum CanvasType
{
    MainGameUI,
    MiniGame_Ball,
    MiniGame_Laser,
    MiniGame_Hacking,
}

[System.Serializable]
public class CanvasData
{
    public CanvasType type;
    public Canvas canvas;
}

//[CreateAssetMenu(fileName = "UIType")]    ��ũ���ͺ� ������Ʈ�� ���� �Ϸ��� ����
//public class CanvasScriptable : ScriptableObject
//{
//    public GameObject prepab;
//}

public class UIManager : Singleton<UIManager>       //��ųʸ��� ���� �����ϴ� �Ŵ���
{
    public List<CanvasData> canvasList;
    private Dictionary<CanvasType, Canvas> canvasDic;

    private MiniGame curMiniGame;

    private void Awake()
    {
        canvasDic = new Dictionary<CanvasType, Canvas>();
        foreach (CanvasData canvasData in canvasList)
        {
            canvasDic[canvasData.type] = canvasData.canvas;
        }

        PuzzleManager.Instance.OnPuzzleZoneEnter += SetMiniGameUI;

        PuzzleManager.Instance.OnpuzzleZoneExit += OffMiniGameUI;
    }

    public void SetMiniGameUI(MiniGame data)
    {
        switch (data.GameIndex)
        {
            //���̽��� ���� ui ���ֱ�
            case 0:
                canvasDic[CanvasType.MiniGame_Ball].gameObject.SetActive(true);
                curMiniGame = data;
                break;
            case 1:
                canvasDic[CanvasType.MiniGame_Hacking].gameObject.SetActive(true);
                curMiniGame = data;
                break;
            case 2:
                canvasDic[CanvasType.MiniGame_Laser].gameObject.SetActive(true);
                curMiniGame = data;
                break;
        }
    }

    public void OffMiniGameUI()
    {
        switch (curMiniGame.GameIndex)
        {
            //���̽��� ���� ui ���ֱ�
            case 0:
                canvasDic[CanvasType.MiniGame_Ball].gameObject.SetActive(false);
                curMiniGame = null;
                break;
            case 1:
                canvasDic[CanvasType.MiniGame_Hacking].gameObject.SetActive(false);
                curMiniGame = null;
                break;
            case 2:
                canvasDic[CanvasType.MiniGame_Laser].gameObject.SetActive(false);
                curMiniGame = null;
                break;
        }
    }

    public void SetMainGameUI() //ESC Ȥ�� ��ư�� Ű ������ �� Ȱ��ȭ ���ΰ��� ����
    {
        canvasDic[CanvasType.MainGameUI].gameObject.SetActive(true);
    }


    public void OffMainGameUI(MiniGame data)
    {
        canvasDic[CanvasType.MainGameUI].gameObject.SetActive(false);
    }
}
