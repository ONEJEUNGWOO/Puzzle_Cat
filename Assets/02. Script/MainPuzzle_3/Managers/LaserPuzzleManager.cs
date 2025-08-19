using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaserPuzzleManager : MonoBehaviour
{
    [SerializeField] private LaserEmitter[] emitters;
    [SerializeField] private LaserReceiver[] receivers;

    // 오브젝트 상태가 변했을 때 발생시킬 이벤트
    public event Action OnObjectChange;

    private void Start()
    {
        emitters = GetComponentsInChildren<LaserEmitter>();
        receivers = GetComponentsInChildren<LaserReceiver>();

        FireAllLaser();
    }

    private void FireAllLaser()
    {
        foreach (LaserEmitter emitter in emitters)
        {
            emitter.FireLaser();
        }
    }

    public void RecalculateLaser()
    {
        StartCoroutine(DelayRecalculate());
    }

    private IEnumerator DelayRecalculate()
    {
        yield return new WaitForSeconds(0.02f);
        OnObjectChange.Invoke();
        FireAllLaser();
    }

    public void CheckCompletion()
    {
        foreach(LaserReceiver receiver in receivers)
        {
            if(!receiver.CheckActive())
            {
                //하나라도 활성화 X
                return;
            }
        }

        Debug.Log("Puzzle Clear");
        // 퍼즐 클리어
        // 클리어 처리는 여기서
    }
}
