﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class UI_Controller : MonoBehaviour
{
    [Inject] private PausePanelController pausePanel;
    [Inject] private PersonController personController;
    void Start()
    {

    }


    void Update()
    {
        
    }

    public void ActivationPauseButton()
    {
        pausePanel.gameObject.SetActive(true);
    }


}