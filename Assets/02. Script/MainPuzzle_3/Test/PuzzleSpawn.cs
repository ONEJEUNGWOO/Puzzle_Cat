using KNJ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawn : MonoBehaviour
{
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

    public Transform spawPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(puzzle1, spawPosition);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(puzzle2, spawPosition);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Instantiate(puzzle3, spawPosition);
        }
        
        if(Input.GetKeyDown(KeyCode.U))
        {
            DataManager.Instance.SaveData();
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            DataManager.Instance.LoadData();
        }
    }
}
