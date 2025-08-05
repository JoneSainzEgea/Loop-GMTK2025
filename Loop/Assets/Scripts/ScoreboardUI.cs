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
        saveButton.onClick.AddListener(SaveScore);
    }

    public void GetLatestScore(int score)
    {
        latestScore = score;
        latestScoreText.text = "Score: " + latestScore;

        // nameInputField.text = "";
        nameInputField.interactable = true;
        saveButton.interactable = true;
        nameInputField.ActivateInputField();

        DisplayScores();
    }

    private void SaveScore()
    {
        string playerName = nameInputField.text.Trim();
        if (string.IsNullOrEmpty(playerName)) return;

        ScoreboardManager.instance.AddScore(playerName, latestScore);
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
