using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class DeathPanelController : MonoBehaviour
{
    [Inject] private PersonController personController;
    [Inject] private EventSystem eventSystem;

    private void Awake()
    {
        personController.GameOver += WaitingForThePanelToOpen;
        Debug.Log("Init");
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
        eventSystem.enabled = true;
        this.gameObject.SetActive(true);
    }



    void Update()
    {
        
    }
}
