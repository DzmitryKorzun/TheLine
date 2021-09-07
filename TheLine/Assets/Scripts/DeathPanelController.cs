using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
public class DeathPanelController : MonoBehaviour
{
    [Inject] private PersonController personController;
    [Inject] private ScorePanelController scorePanelController;
    [Inject] private EventSystem eventSystem;
    private Text scoreText;
    private void Awake()
    {
        personController.GameOver += WaitingForThePanelToOpen;
        scoreText = GetComponentInChildren<Text>();
    }

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void WaitingForThePanelToOpen()
    {
        eventSystem.enabled = false;
        Invoke("ActivatePanel", 2);
    }


    private void ActivatePanel()
    {
        scoreText.text = scorePanelController.GetResultGame();
        eventSystem.enabled = true;
        this.gameObject.SetActive(true);
    }



    void Update()
    {
        
    }
}
