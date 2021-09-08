using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class SoundController : MonoBehaviour
{
    [SerializeField] private Sprite soundOnImage;
    [SerializeField] private Sprite soundOffImage;
    [SerializeField] private bool isSoundActive = true;
    [Inject] private AudioSource audioSource;
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
            PlayerPrefs.SetInt("Sound", 0);
            audioSource.Stop();
        }
        else
        {
            imageButton.sprite = soundOnImage;
            isSoundActive = !isSoundActive;
            PlayerPrefs.SetInt("Sound", 1);
            audioSource.Play();
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            audioSource.Play();
            imageButton.sprite = soundOnImage;
        }
        if (PlayerPrefs.GetInt("Sound", 1) == 0)
        {
            audioSource.Stop();
            imageButton.sprite = soundOffImage;
        }
    }
}
