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
        LookAround(); // LookAround �޼��带 �ݺ� ȣ���Ͽ� ī�޶� ȸ���� ó���մϴ�.
    }
    private void LookAround()
    {
        curMouseX = Input.GetAxis("Mouse X"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        curMouseY = Input.GetAxis("Mouse Y"); // ���콺�� ���� �̵� �Է��� �����ɴϴ�.
        Vector2 mouseDelta = new Vector2(curMouseX, curMouseY);
        // ���콺 ��Ÿ�� ������ Vector2�� ����ϴ�. �ȿ��� ���콺 ���� �� ���� �̵� ���� ���ϴ�.
        // ���α׷��ֿ����� "��Ÿ"��� �� ��ȭ���� ��Ÿ���� �� ���˴ϴ�. (������ ���� ���� ���̸� ��Ÿ����.)
        Vector3 camAngle = cameraContainer.rotation.eulerAngles;
        // camAngl�̶�� Vector3 ���� cameraContainer�� ȸ�� ���� �����մϴ�.
        // rotation�� 4���� ������ �ΰ��� �����ϱ� ���� x, y, z ���� ȸ�� ���� ��Ÿ���� ���� eulerAngle�� ����� ��ȯ�մϴ�.
        // ���� ���: camAngle.x = ���Ʒ� ����, camAngle.y = �¿� ����, camAngle.z = ����
        // ���������� camAngle �� mouseDelta�� ���� ���ο� ȸ������ ����� �ݴϴ�.

        //���Ʒ��� ������ ������ �ֱ����� camAngle.x - mouseDelta.y�� ������ ����� ������ �ְ� ������ �ɾ �����մϴ�
        float x = camAngle.x - mouseDelta.y;
        if (x < 180) // camAngle.x�� 180������ ������ �������� ȸ���ϴ� ��
        {
            x = Mathf.Clamp(x, -1f, 70f); 
            // -1f�� ���� ȸ���� �� �ִ� �ּҰ�, 70f�� ���� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }
        else // camAngle.x�� 180������ ũ�� �Ʒ������� ȸ���ϴ� ��
        {
            x = Mathf.Clamp(x, 335f, 361f);
            // 335f�� �Ʒ��� ȸ���� �� �ִ� �ּҰ�, 361f�� �Ʒ��� ȸ���� �� �ִ� �ִ밪�Դϴ�.
        }

        // �׸��� ���θ������ ȸ������ cameraContainer.rotation�� �־��ݴϴ�.
        cameraContainer.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, 0);
        // camAngle.y�� 3���������� ����������ϰ� mouseDelta.x �� 2�������� ���� �̵��� ����մϴ�.
        // ���� camAngle.y + mouseDelta.x �� ���� ȸ���� ����մϴ�. �� mouseDelta.x ���찡 �¿�� �����̴� �ǽð� ��ȭ�ϴ� ���� 
        // camAngle.y�� �����ݴϴ�.
        // camAngle.x�� mouseDelta.y�� ���� ������ ���Ʒ� ������ ����մϴ�.
    }
}
