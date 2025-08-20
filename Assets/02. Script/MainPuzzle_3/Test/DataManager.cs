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

            // 게임 매니저로 플레이어 위치랑 회전 정보 가져옴
            Vector3 playerPos = CharacterManager.Instance.Player.transform.position;
            curSaveData.playerPosition = new float[3] { playerPos.x, playerPos.y, playerPos.z };
            Quaternion playerRot = CharacterManager.Instance.Player.transform.rotation;
            curSaveData.playerRotation = new float[4] {playerRot.x, playerRot.y, playerRot.z, playerRot.w};
            // 게임 매니저에서 퍼즐 클리어 정보 가져옴 (퍼즐 고유 아이디랑 클리어 여부)
            curSaveData.puzzleClearData = new List<GameClearData>();
            Dictionary<string, bool> puzzleClearData = PuzzleDataManager.Instance.puzzleClearData;
            foreach (KeyValuePair<string, bool> kvp in puzzleClearData)
            {
                curSaveData.puzzleClearData.Add(new GameClearData(kvp.Key, kvp.Value));
            }

            string json = JsonUtility.ToJson(curSaveData, true);
            File.WriteAllText(Application.persistentDataPath + "/save.json", json);

            Debug.Log($"데이터 저장 성공!\n{Application.persistentDataPath}");
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
                Debug.Log("데이터 불러오기 실패");
                return false;
            }

            // 불러올 데이터가 없는 경우
            if(data == null)
            {
                Debug.Log("데이터 불러오기 실패");
                return false;

            }

            Debug.Log("데이터 불러오기 성공");
            return true;
        }

        public Vector3 GetPlayerPositionData()
        {
            if(curSaveData == null)
            {
                Debug.Log("불러올 데이터가 없습니다.");
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

