using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawn : MonoBehaviour
{
    public GameObject puzzle1;
    public GameObject puzzle2;
    public GameObject puzzle3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(puzzle1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Instantiate(puzzle2);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Instantiate(puzzle3);
        }
    }
}
