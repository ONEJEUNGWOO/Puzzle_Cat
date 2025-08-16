using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCaracterController : MonoBehaviour
{
    [SerializeField] private Transform CharacterBody;
    [SerializeField] private Transform cameraContainer;

    private float curMouseX;
    private float curMouseY;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        LookAround(); // LookAround 메서드를 반복 호출하여 카메라 회전을 처리합니다.
    }
    private void LookAround()
    {
        curMouseX = Input.GetAxis("Mouse X"); // 마우스의 수평 이동 입력을 가져옵니다.
        curMouseY = Input.GetAxis("Mouse Y"); // 마우스의 수직 이동 입력을 가져옵니다.
        Vector2 mouseDelta = new Vector2(curMouseX, curMouseY);
        // 마우스 델타를 저장할 Vector2를 만듭니다. 안에는 마우스 수평 및 수직 이동 값이 들어갑니다.
        // 프로그래밍에서는 "델타"라는 용어가 변화량을 나타내는 데 사용됩니다. (이전과 현제 값의 차이를 나타낸다.)
        Vector3 camAngle = cameraContainer.rotation.eulerAngles;
        // camAngl이라는 Vector3 값에 cameraContainer의 회전 값을 저장합니다.
        // rotation은 4차원 값으로 인간이 이해하기 쉬운 x, y, z 축의 회전 값을 나타내기 위해 eulerAngle을 사용해 변환합니다.
        // 최종 결과: camAngle.x = 위아래 각도, camAngle.y = 좌우 각도, camAngle.z = 기울기
        // 마지막으로 camAngle 과 mouseDelta를 합쳐 새로운 회전값을 만들어 줍니다.

        //위아래의 각도에 제한을 주기위해 camAngle.x - mouseDelta.y를 변수를 만들어 저장해 주고 조건을 걸어서 제한합니다
        float x = camAngle.x - mouseDelta.y;
        if (x < 180) // camAngle.x가 180도보다 작으면 위쪽으로 회전하는 것
        {
            x = Mathf.Clamp(x, -1f, 70f); 
            // -1f는 위로 회전할 수 있는 최소값, 70f는 위로 회전할 수 있는 최대값입니다.
        }
        else // camAngle.x가 180도보다 크면 아래쪽으로 회전하는 것
        {
            x = Mathf.Clamp(x, 335f, 361f);
            // 335f는 아래로 회전할 수 있는 최소값, 361f는 아래로 회전할 수 있는 최대값입니다.
        }

        // 그리고 새로만들어진 회전값을 cameraContainer.rotation에 넣어줍니다.
        cameraContainer.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, 0);
        // camAngle.y는 3차원에서는 수평을담당하고 mouseDelta.x 는 2차원에서 수평 이동을 담당합니다.
        // 따라서 camAngle.y + mouseDelta.x 는 수평 회전을 담당합니다. 즉 mouseDelta.x 마우가 좌우로 움직이는 실시간 변화하는 값을 
        // camAngle.y에 더해줍니다.
        // camAngle.x와 mouseDelta.y도 같은 원리로 위아래 방향을 답당합니다.
    }
}
