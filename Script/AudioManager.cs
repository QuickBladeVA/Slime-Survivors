using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
    private void Start()
    {
        // Initialize the slider value to the current volume.
        volumeSlider.value = AudioListener.volume;
    }

    public void OnVolumeSliderChanged()
    {
        // Update the global audio volume when the slider is adjusted.
        AudioListener.volume = volumeSlider.value;
    }
}
