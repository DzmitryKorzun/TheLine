using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScorePanelController : MonoBehaviour
{
    [Inject] private PersonController personController;
    [SerializeField] private float scoreCount = 0;
    [SerializeField] private bool isScoreCounting = true;
    [SerializeField] private float scoringSpeed = 0.5f;
    private Text scoreText;
    private void Awake()
    {
        personController.OnStartGame += ContinueScoring;
        personController.OnPauseGame += StopScoring;
        personController.GameOver += StopScoring;
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



    private void FixedUpdate()
    {
        if (isScoreCounting)
        {
            scoreCount+= scoringSpeed;
            scoreText.text = Mathf.Round(scoreCount).ToString();
        }        
    }
}
