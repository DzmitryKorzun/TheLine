using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public event Action OnPauseGame;
    public event Action OnStartGame;
    [Inject] private PausePanelController pausePanel;
    public void ActivationPauseButton()
    {
        pausePanel.gameObject.SetActive(true);
        OnPauseGame?.Invoke();
        DOTween.PauseAll();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueGame()
    {
        pausePanel.gameObject.SetActive(false);
        OnStartGame?.Invoke();
        DOTween.PlayAll();
    }

}
