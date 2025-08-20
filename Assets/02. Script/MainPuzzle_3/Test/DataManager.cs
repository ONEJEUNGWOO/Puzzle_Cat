using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace KNJ
{
    [System.Serializable]
    public class SaveData
    {
        public float[] playerPosition;
        public float[] playerRotation;
        public List<GameClearData> puzzleClearData;
    }

    [System.Serializable]
    public struct GameClearData
    {
        public string id;
        public bool isClear;

        public GameClearData(string id, bool isClear)
        {
            this.id = id;
            this.isClear = isClear;
        }
    }

    public class DataManager : Singleton<DataManager>
    {
        private SaveData curSaveData;

        public void SaveData()
        {
            curSaveData = new SaveData();

            // ���� �Ŵ����� �÷��̾� ��ġ�� ȸ�� ���� ������
            Vector3 playerPos = CharacterManager.Instance.Player.transform.position;
            curSaveData.playerPosition = new float[3] { playerPos.x, playerPos.y, playerPos.z };
            Quaternion playerRot = CharacterManager.Instance.Player.transform.rotation;
            curSaveData.playerRotation = new float[4] {playerRot.x, playerRot.y, playerRot.z, playerRot.w};
            // ���� �Ŵ������� ���� Ŭ���� ���� ������ (���� ���� ���̵�� Ŭ���� ����)
            curSaveData.puzzleClearData = new List<GameClearData>();
            Dictionary<string, bool> puzzleClearData = PuzzleDataManager.Instance.puzzleClearData;
            foreach (KeyValuePair<string, bool> kvp in puzzleClearData)
            {
                curSaveData.puzzleClearData.Add(new GameClearData(kvp.Key, kvp.Value));
            }

            string json = JsonUtility.ToJson(curSaveData, true);
            File.WriteAllText(Application.persistentDataPath + "/save.json", json);

            Debug.Log($"������ ���� ����!\n{Application.persistentDataPath}");
        }

        public bool LoadData()
        {
            SaveData data = null;

            try
            {
                string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
                data = JsonUtility.FromJson<SaveData>(json);
            }
            catch
            {
                Debug.Log("������ �ҷ����� ����");
                return false;
            }

            // �ҷ��� �����Ͱ� ���� ���
            if(data == null)
            {
                Debug.Log("������ �ҷ����� ����");
                return false;

            }

            Debug.Log("������ �ҷ����� ����");
            return true;
        }

        public Vector3 GetPlayerPositionData()
        {
            if(curSaveData == null)
            {
                Debug.Log("�ҷ��� �����Ͱ� �����ϴ�.");
            }

            return new Vector3(curSaveData.playerPosition[0],  curSaveData.playerPosition[1], curSaveData.playerPosition[2]);
        }

        public Quaternion GetPlayerRotationData()
        {
            return new Quaternion(curSaveData.playerRotation[0], curSaveData.playerRotation[1], curSaveData.playerRotation[2], curSaveData.playerRotation[3]);
        }

        public Dictionary<string, bool> GetGameClearData()
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach(GameClearData data in curSaveData.puzzleClearData)
            {
                dic[data.id] = data.isClear;
            }

            return dic;
        }
    }

}

