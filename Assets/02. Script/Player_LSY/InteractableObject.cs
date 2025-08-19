using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string InteractionText; // 상호작용할 때 표시될 텍스트
    public virtual void Interact()
    // 상호작용을 처리하는 함수
    // virtual 키워드를 사용하여 상속받은 클래스에서 오버라이드할 수 있도록 합니다.
    {
        Debug.Log("상호작용");
    }
}
