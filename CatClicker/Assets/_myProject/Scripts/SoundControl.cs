using UnityEngine;
using UnityEngine.UI;
using YG;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private float[] volume;
    [SerializeField] private Image soundButton;

    [SerializeField] private Sprite soundOn;
    [SerializeField] private Sprite soundOff;

    public bool SoundOff;

    // On or off sounds in game
    public void Click()
    {
        SoundOff = !SoundOff;
        UpdateSound();
    }

    public void UpdateSound()
    {
        if (SoundOff)
        {
            soundButton.sprite = soundOff;
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = 0;
            }
        }
        else
        {
            soundButton.sprite = soundOn;
            for (int i = 0; i < audioSources.Length; i++)
            {
                audioSources[i].volume = volume[i];
            }
        }
    }
}
