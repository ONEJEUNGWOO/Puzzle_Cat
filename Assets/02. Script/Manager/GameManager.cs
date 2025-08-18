using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // 클리어 했는지

    public List<bool> GameCleared = new List<bool>();

    public void isGameCleared(bool clear, int index)
    {
        if (index > GameCleared.Count - 1) return;
        GameCleared[index] = clear;
    }

    public void GravityScale(Vector3 scale)
    {
        Physics.gravity = scale;
    }


    // 시간 관련


}
