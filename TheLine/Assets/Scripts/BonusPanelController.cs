using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusPanelController : MonoBehaviour
{
    private Text textSec;


    void Start()
    {
        textSec = GetComponentInChildren<Text>();
        this.gameObject.SetActive(false);
    }

    public void timeOutput(string myTime)
    {
        textSec.text = myTime;
    }
}
