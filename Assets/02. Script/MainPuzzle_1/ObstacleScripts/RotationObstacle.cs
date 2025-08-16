using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    public Vector3 dir = new Vector3(0f, 1f, 0f);
    private float test;
    private float progress = 0f;
    public int minSpeed;
    public int maxSpeed;
    public int cycleDuration;


    private void Update()
    {
        progress = Mathf.PingPong(Time.time / cycleDuration, 1f);
        //이 오브젝트의 트렌스 폼 로테이션 값을 계속 변경 시켜라.
        transform.Rotate(dir * Mathf.Lerp(minSpeed,maxSpeed, progress));
        test = Mathf.Lerp(minSpeed, maxSpeed, progress);
        Debug.Log(test);
    }
}
