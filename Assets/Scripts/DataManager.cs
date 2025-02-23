using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IO;
using System.IO;

public class DataManager : MonoBehaviour {
    public static DataManager Instance { get; private set; }
    public string playerName = "";
    public List<HighScore> highScores = new List<HighScore>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }
    }

    public void AddScore(HighScore highScore) {
        highScores.Add(highScore);
        highScores.Sort((a, b) => b.score.CompareTo(a.score));
        if (highScores.Count > 10) {
            highScores.RemoveAt(10);
        }
    }

    [System.Serializable]
    public class HighScore {
        public string playerName;
        public int score;
    }

    [System.Serializable]
    public class HighScoreList {
        public List<HighScore> scores;
    }

    [System.Serializable]
    class PlayerName{
        public string playerName;
    }

    public void SavePlayerName() {
        PlayerName data = new PlayerName();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/player_savefile.json", json);
    }

    public void LoadPlayerName() {
        string path = Application.persistentDataPath + "/player_savefile.json";
        Debug.Log(path);
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            PlayerName data = JsonUtility.FromJson<PlayerName>(json);

            playerName = data.playerName;
        }
    }
    public void SaveHighScores() {
        HighScoreList hsl = new HighScoreList();
        hsl.scores = highScores;
        string json = JsonUtility.ToJson(hsl);
        
        File.WriteAllText(Application.persistentDataPath + "/scores_savefile.json", json);
    }

    public void LoadHighScores() {
        string path = Application.persistentDataPath + "/scores_savefile.json";
        Debug.Log(path);
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            HighScoreList hsl = JsonUtility.FromJson<HighScoreList>(json);
            highScores = hsl.scores;
        }
    }
}
