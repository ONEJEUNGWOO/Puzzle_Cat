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
        //�� ������Ʈ�� Ʈ���� �� �����̼� ���� ��� ���� ���Ѷ�.
        transform.Rotate(dir * Mathf.Lerp(minSpeed,maxSpeed, progress));
        test = Mathf.Lerp(minSpeed, maxSpeed, progress);
        Debug.Log(test);
    }
}
