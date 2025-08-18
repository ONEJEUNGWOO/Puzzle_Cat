using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string InteractionText; // 상호작용할 때 표시될 텍스트
    public void Interact()
    // 상호작용을 처리하는 함수
    {
        Debug.Log("상호작용");
    }
}
