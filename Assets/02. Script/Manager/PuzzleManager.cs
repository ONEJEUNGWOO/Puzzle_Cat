using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    public GameObject obj;

    public MiniGame miniGame;

    public MiniGameData miniGameData;

    public Action Reward;

    public event Action<MiniGame> OnPuzzleZoneEnter;
    public event Action OnpuzzleZoneExit;

    private void Start()
    {
        miniGameData = GetComponent<MiniGameData>();
    }

    public void PuzzleIn(MiniGame data)
    {
        OnPuzzleZoneEnter?.Invoke(data);
    }

    public void PuzzleExit()
    {
        OnpuzzleZoneExit?.Invoke();
    }

    public void SetPuzzle(MiniGame data, int level)
    {
        if (obj != null)
        {
            DestroyObj();
        }

        miniGame = data;

        obj = Instantiate(data.levels[level], transform.position, transform.rotation, transform);
    }

    public void PuzzleClear()
    {
        GameManager.Instance.isGameCleared(true, miniGame.GameIndex);
        PuzzleExit();
        DestroyObj();
    }

    public void DestroyObj()
    {
        Destroy(obj);
    }
}
