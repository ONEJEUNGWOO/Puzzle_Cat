using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    public GameObject obj;

    public MiniGame miniGame;


    public Action Reward;

    public event Action<MiniGame> OnPuzzleZoneEnter;
    public event Action OnpuzzleZoneExit;

    public Transform currentRwdTrs;



    public void PuzzleIn(MiniGame data, Transform rwdTrs)
    {
        miniGame = null;
        currentRwdTrs = null;
        OnPuzzleZoneEnter?.Invoke(data);

        if (obj != null)
        {
            DestroyObj();
        }

        miniGame = data;
        currentRwdTrs = rwdTrs;
        obj = Instantiate(data.levels, transform.position, transform.rotation, transform);
    }

    public void PuzzleExit()
    {
        OnpuzzleZoneExit?.Invoke();
    }


    public void PuzzleClear()
    {
        if (miniGame.reward != null && currentRwdTrs != null)
        {
            SpawnReward();
            Debug.Log("Spawn!");
        }
        PuzzleDataManager.Instance.isGameCleared(miniGame);
        PuzzleExit();
        DestroyObj();
    }

    public void SpawnReward()
    {
        Instantiate(miniGame.reward, currentRwdTrs.position, currentRwdTrs.rotation);
    }

    public void DestroyObj()
    {
        Destroy(obj);
    }
}
