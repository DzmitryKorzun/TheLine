using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class UI_Controller : MonoBehaviour
{

    [Inject] private PausePanelController pausePanel;

    public void ActivationPauseButton()
    {
        pausePanel.gameObject.SetActive(true);
    }


}
