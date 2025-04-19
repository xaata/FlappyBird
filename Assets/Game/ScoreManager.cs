using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score = 0;
    private int _highScore = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreTextGameOverUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextGameOverUI;
    public int Score { get => _score; }
    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    public void AddScore()
    {    
        _score++;
        UpdateScoreUI();
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
            
            //Debug.Log("New HighScore = " + _highScore);
        }
    }
    public void NullifyScore()
    {
        _score = 0;
    }
    private void UpdateScoreUI()
    {
        _scoreText.SetText(_score.ToString());
        _currentScoreTextGameOverUI.SetText(_score.ToString());
        _bestScoreTextGameOverUI.SetText(_highScore.ToString());
        PlayerPrefs.SetInt("Score", _score);//optimize it
        //Debug.Log($"Score: {_score}");
    }
}
