using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        PuzzleManager.Instance.OnPuzzleZoneEnter += HandlePuzzleIn;
        PuzzleManager.Instance.OnpuzzleZoneExit += HandlePuzzleExit;
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
