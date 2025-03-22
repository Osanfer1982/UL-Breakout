using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoresScreen : MonoBehaviour {

    public TextMeshProUGUI scores;
    void Start() {
        foreach (DataManager.HighScore hs in DataManager.Instance.highScores) {
            int index = DataManager.Instance.highScores.IndexOf(hs);
            scores.text += $"{index+1}.- {hs.playerName}: {hs.score} pts.\n";
        }
    }
}
