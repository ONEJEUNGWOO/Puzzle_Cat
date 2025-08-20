using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : Singleton<GameManager>
{
    // 클리어 했는지

    public List<bool> isMainCleared = new List<bool>();
    public List<bool> isSubCleared = new List<bool>();

    private void Start()
    {
        PuzzleManager.Instance.OnPuzzleZoneEnter += HandlePuzzleIn;
        PuzzleManager.Instance.OnpuzzleZoneExit += HandlePuzzleExit;
    }

    public void isGameCleared(bool ismain, int index)
    {
        if (!ismain)
        {
            isSubCleared[index] = true;
            return;
        }
        else
        {
            isMainCleared[index] = true;
        }
        foreach (var amount in isMainCleared)
        {
            if (!amount)
            {
                return;
            }
        }
        Debug.Log("게임 클리어!");
    }

    private void HandlePuzzleIn(MiniGame data)
    {
        if (data.isGravityUse)
        {
            Physics.gravity = data.GravityScale;
        }

        PlayerInput input = CharacterManager.Instance.Player.GetComponent<PlayerInput>();

        if (input != null)
        {
            input.SwitchCurrentActionMap("BallPuzzle");
        }

        Cursor.lockState = CursorLockMode.None;
    }

    private void HandlePuzzleExit()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);

        PlayerInput input = CharacterManager.Instance.Player.GetComponent<PlayerInput>();

        if (input != null)
        {
            input.SwitchCurrentActionMap("KittyAction");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }


    // 시간 관련


}
