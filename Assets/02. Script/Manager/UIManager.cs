using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

//[CreateAssetMenu(fileName = "UIType")]    스크립터블 오브젝트로 관리 하려다 실패
//public class CanvasScriptable : ScriptableObject
//{
//    public GameObject prepab;
//}

public class UIManager : Singleton<UIManager>       //딕셔너리를 통해 관리하는 매니저
{
    public List<CanvasData> canvasList;
    private Dictionary<CanvasType, Canvas> canvasDic;

    private bool isSetMainGame;

    private void Awake()
    {
        canvasDic = new Dictionary<CanvasType, Canvas>();
        foreach (CanvasData canvasData in canvasList)
        {
            canvasDic[canvasData.type] = canvasData.canvas;
        }

        PuzzleManager.Instance.OnPuzzleZoneEnter += SetMiniGameUI;

        PuzzleManager.Instance.OnpuzzleZoneExit += OffMiniGameUI;

        OffMainGameUI();
        OffMiniGameUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isSetMainGame)
                SetMainGameUI();
            else
                OffMainGameUI();
        }
    }

    public void SetMiniGameUI(MiniGame data)
    {
        switch (data.GameIndex)
        {
            //케이스에 따라 ui 켜주기
            case 0:
                Debug.Log("실행은 됨?");
                canvasDic[CanvasType.MiniGame_Ball].gameObject.SetActive(true);
                break;
            case 1:
                canvasDic[CanvasType.MiniGame_Hacking].gameObject.SetActive(true);
                break;
            case 2:
                canvasDic[CanvasType.MiniGame_Laser].gameObject.SetActive(true);
                break;
        }
    }

    public void OffMiniGameUI()
    {
        canvasDic[CanvasType.MiniGame_Ball].gameObject.SetActive(false);
        canvasDic[CanvasType.MiniGame_Hacking].gameObject.SetActive(false);
        canvasDic[CanvasType.MiniGame_Laser].gameObject.SetActive(false);
    }

    public void SetMainGameUI() //ESC 혹은 버튼등 키 눌렀을 때 활성화 메인게임 관련
    {
        isSetMainGame = true;
        Cursor.lockState = CursorLockMode.Confined;
        canvasDic[CanvasType.MainGameUI].gameObject.SetActive(true);
    }


    public void OffMainGameUI()
    {
        isSetMainGame = false;
        Cursor.lockState = CursorLockMode.Locked;
        canvasDic[CanvasType.MainGameUI].gameObject.SetActive(false);
    }
}
