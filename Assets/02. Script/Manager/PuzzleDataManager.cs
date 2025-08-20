using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDataManager : Singleton<PuzzleDataManager>
{
    public Dictionary<string, bool> puzzleClearData = new Dictionary<string, bool>();

    public List<MiniGame> mainPuzzleCheck;

    public Action Clear;

    public void isGameCleared(MiniGame data)
    {
        string id = data.GameID;

        if (puzzleClearData.ContainsKey(id))
        {
            puzzleClearData[id] = true;
        }
        else
        {
            puzzleClearData.Add(id, true);
        }

        CheckGameClear();
        Clear?.Invoke();
    }

    private void CheckGameClear()
    {
        foreach (MiniGame mainPuzzle in mainPuzzleCheck)
        {
            string id = mainPuzzle.GameID;

            if (!puzzleClearData.ContainsKey(id) || !puzzleClearData[id])
            {
                return;
            }
        }

        Debug.Log("¿£µù¾À");
    }

}
