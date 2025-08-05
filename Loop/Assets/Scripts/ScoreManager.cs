// Jone Sainz Egea
// 31/07/2025
    // Score goes up with time and shows in screen
// 02/08/2025
    // Hearts management added

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    // Score
    public float score { get; private set; } = 0f;
    [SerializeField] private float baseIncreaseRate = 1f;
    private float scoreMultiplier = 1f;
    [SerializeField] private TextMeshProUGUI scoreText;

    // Hearts
    [SerializeField] private int totalHearts = 3;
    public static int currentHearts;
    [SerializeField] private List<Image> heartImages;
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;

    private void OnEnable()
    {
        GameManager.OnRetry += Restart;
    }

    private void OnDisable()
    {
        GameManager.OnRetry -= Restart;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHearts = totalHearts;
        UpdateHeartsDisplay();
    }

    void Update()
    {
        score += baseIncreaseRate * scoreMultiplier * Time.deltaTime;
        UpdateScoreText();
    }

    #region Points
    public void AddPoints(float amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void SubtractPoints(float amount)
    {
        // TODO: change text color
        score -= amount;
        if (score < 0f) score = 0f;
        UpdateScoreText();
    }

    public void SetScoreMultiplier(float multiplier)
    {
        scoreMultiplier = multiplier;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {Mathf.FloorToInt(score)}";
        }
    }
    #endregion

    #region Hearts
    public void SubstractHearts(int amount = 1)
    {
        currentHearts -= amount;
        currentHearts = Mathf.Clamp(currentHearts, 0, totalHearts);

        UpdateHeartsDisplay();

        if (currentHearts <= 0)
        {
            int scoreINT = Mathf.FloorToInt(score);
            GameManager.instance.GameOver(scoreINT);
            return;
        }
    }

    private void UpdateHeartsDisplay()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < currentHearts)
                heartImages[i].sprite = fullHeartSprite;
            else
                heartImages[i].sprite = emptyHeartSprite;
        }
    }

    public void Restart()
    {
        currentHearts = totalHearts;
        UpdateHeartsDisplay();
        score = 0f;
        scoreMultiplier = 1f;
    }
    #endregion
}
