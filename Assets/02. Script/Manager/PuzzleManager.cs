using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : Singleton<PuzzleManager>
{
    public GameObject obj;

    public MiniGame miniGame;

    public void SetPuzzle(MiniGame data, int level)
    {
        if (obj != null)
        {
            Destroy(obj);
        }

        miniGame = data;

        obj = Instantiate(data.levels[level], transform.position, transform.rotation, transform);


       if (data.isGravityUse)
        {
            GameManager.Instance.GravityScale(data.GravityScale);
        }
    }

    public void PuzzleClear()
    {
        GameManager.Instance.isGameCleared(true, miniGame.GameIndex);
    }

    //public bool isMain(bool main)
    //{
        
    //}
}
