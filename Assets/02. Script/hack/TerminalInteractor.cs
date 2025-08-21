using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalInteractor : MonoBehaviour
{
    [Header("Assign the UI Prefab (Canvas ���� ������)")]
    public GameObject hackingUIPrefab;

    private GameObject currentHackingUI = null;
    private HackingMiniManager miniManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentHackingUI == null) StartHacking();
            else StopHacking();
        }
    }

    void StartHacking()
    {
        if (!hackingUIPrefab)
        {
            Debug.LogError("[TerminalInteractor] hackingUIPrefab ���Ҵ�!");
            return;
        }

        currentHackingUI = Instantiate(hackingUIPrefab);

        // ��Ʈ/�ڽ� ��� �پ��ֵ� �����ϰ� ã��
        miniManager = currentHackingUI.GetComponentInChildren<HackingMiniManager>(true);
        if (miniManager == null)
        {
            Debug.LogError("[TerminalInteractor] �����տ��� HackingMiniManager�� ã�� ���߽��ϴ�. ������ ������ Ȯ���ϼ���.");
            return;
        }

        // ���� ����(����/Ÿ�Ӿƿ�) �̺�Ʈ ����
        miniManager.OnGameFinished += HandleGameFinished;

        // EventSystem ������ UI �Է��� �� ����
        EnsureEventSystem();
    }

    void StopHacking()
    {
        if (miniManager != null)
        {
            miniManager.OnGameFinished -= HandleGameFinished;
            miniManager = null;
        }

        if (currentHackingUI != null)
        {
            Destroy(currentHackingUI);
            currentHackingUI = null;
        }
    }

    private void HandleGameFinished(bool success)
    {
        if (success) Debug.Log("��ŷ ����! ������ �����մϴ�.");
        else Debug.Log("��ŷ ����. �͹̳��� ���ϴ�.");

        StartCoroutine(CloseUIAfterDelay(1.5f));
    }

    private IEnumerator CloseUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StopHacking();
    }

    private void EnsureEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            var go = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            DontDestroyOnLoad(go);
        }
    }
}
