using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    public static ScoreboardManager instance;

    private const string SCOREBOARD_KEY = "ScoreboardData";
    private List<ScoreEntry> scores = new List<ScoreEntry>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public List<ScoreEntry> GetScores()
    {
        return scores.OrderByDescending(s => s.score).ToList();
    }

    public void AddScore(string name, int score)
    {
        name = name.Length > 10 ? name.Substring(0, 10) : name;
        scores.Add(new ScoreEntry(name, score));
        SaveScores();
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(new ScoreListWrapper { list = scores });
        PlayerPrefs.SetString(SCOREBOARD_KEY, json);
        PlayerPrefs.Save();
    }

    private void LoadScores()
    {
        if (PlayerPrefs.HasKey(SCOREBOARD_KEY))
        {
            string json = PlayerPrefs.GetString(SCOREBOARD_KEY);
            ScoreListWrapper wrapper = JsonUtility.FromJson<ScoreListWrapper>(json);
            scores = wrapper.list ?? new List<ScoreEntry>();
        }
    }

    [System.Serializable]
    private class ScoreListWrapper
    {
        public List<ScoreEntry> list;
    }
}
