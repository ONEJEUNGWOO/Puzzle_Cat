using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string InteractionText; // �������� �� ǥ�õ� �ؽ�Ʈ
    public virtual void Interact()
    // ��ȣ�ۿ��� ó���ϴ� �Լ�
    // virtual Ű���带 ����Ͽ� ��ӹ��� Ŭ�������� �������̵��� �� �ֵ��� �մϴ�.
    {
        Debug.Log("��ȣ�ۿ�");
    }
}
