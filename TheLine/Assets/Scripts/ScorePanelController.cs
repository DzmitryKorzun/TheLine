using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScorePanelController : MonoBehaviour
{
    [Inject] private PersonController personController;
    [SerializeField] private float scoreCount = 0;
    [SerializeField] private bool isScoreCounting = true;
    [SerializeField] private float scoringSpeed = 0.5f;
    private StringBuilder stringBuilder;
    private Text scoreText;
    private void Awake()
    {
        personController.OnStartGame += ContinueScoring;
        personController.OnPauseGame += StopScoring;
        personController.GameOver += StopScoring;
        stringBuilder = new StringBuilder();
    }

    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    private void ContinueScoring()
    {
        isScoreCounting = true;
    }

    private void StopScoring()
    {
        isScoreCounting = false;
    }

    public string GetResultGame()
    {
        stringBuilder.Clear();
        if (PlayerPrefs.GetInt("Score", 0) < scoreCount)
        {
            stringBuilder.AppendFormat("SCORE:\n {0}\n BEST SCORE\n{1}", Mathf.Round(scoreCount), Mathf.Round(scoreCount));
            PlayerPrefs.SetInt("Score", Mathf.RoundToInt(scoreCount));
        }
        else
        {
            stringBuilder.AppendFormat("SCORE:\n {0}\n BEST SCORE\n{1}", Mathf.Round(scoreCount), PlayerPrefs.GetInt("Score", 0));
        }
        
        return stringBuilder.ToString();
    }

    private void FixedUpdate()
    {
        if (isScoreCounting)
        {
            scoreCount+= scoringSpeed;
            scoreText.text = Mathf.Round(scoreCount).ToString();
        }        
    }
}
