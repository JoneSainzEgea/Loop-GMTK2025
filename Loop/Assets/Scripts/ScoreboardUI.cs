using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreboardUI : MonoBehaviour
{
    [SerializeField] private GameObject scoreBoardPanel;
    [SerializeField] private TMP_Text latestScoreText;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button saveButton;
    [SerializeField] private Transform scoreboardContent;
    [SerializeField] private GameObject scoreEntryPrefab;

    private int latestScore;

    private void Start()
    {
        scoreBoardPanel.SetActive(false);
        saveButton.onClick.AddListener(SaveScore);
    }

    public void GetLatestScore(int score)
    {
        latestScore = score;
        latestScoreText.text = "Score: " + latestScore;
        nameInputField.text = "";
        DisplayScores();
    }

    private void SaveScore()
    {
        string playerName = nameInputField.text.Trim();
        if (string.IsNullOrEmpty(playerName)) return;

        int score = Mathf.FloorToInt(latestScore);
        ScoreboardManager.instance.AddScore(playerName, score);
        DisplayScores();
        saveButton.interactable = false;
        nameInputField.interactable = false;
    }

    private void DisplayScores()
    {
        foreach (Transform child in scoreboardContent)
            Destroy(child.gameObject);

        foreach (var entry in ScoreboardManager.instance.GetScores())
        {
            GameObject item = Instantiate(scoreEntryPrefab, scoreboardContent);
            item.GetComponent<TMP_Text>().text = $"{entry.playerName} - {entry.score}";
        }
    }
}
