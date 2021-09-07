using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Sprite soundOnImage;
    [SerializeField] private Sprite soundOffImage;
    [SerializeField] private bool isSoundActive = true;
    private Image imageButton; 
    void Start()
    {
        imageButton = GetComponent<Image>();
    }

    public void ChangeSoundStatus()
    {
        if (isSoundActive)
        {
            imageButton.sprite = soundOffImage;
            isSoundActive = !isSoundActive;
        }
        else
        {
            imageButton.sprite = soundOnImage;
            isSoundActive = !isSoundActive;
        }
    }
}
