using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour {
    [SerializeField] GameObject nameInputField;

    void Start() {
        DataManager.Instance.LoadPlayerName();
        DataManager.Instance.LoadHighScores();
        nameInputField.GetComponent<TMP_InputField>().text = DataManager.Instance.playerName;
    }

    public void StartGame() {
        DataManager.Instance.playerName = nameInputField.GetComponent<TMP_InputField>().text;
        DataManager.Instance.SavePlayerName();
        SceneManager.LoadScene(1);
    }
    public void HighScores() {
        SceneManager.LoadScene(2);
    }

    public void Exit() {
        DataManager.Instance.SavePlayerName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
