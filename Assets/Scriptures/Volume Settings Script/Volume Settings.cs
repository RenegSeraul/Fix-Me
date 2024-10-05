using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer daMixer;
    [SerializeField] private Slider musicSlide;
    [SerializeField] private Slider SFXSlide;

    #region -- Functions --
    // -- Makes the audio mixer compatible with the slider (i.e., able to see changes in the audio mixers) --
    public void Start()
    {
        // -- Confirms the saved preferences and loads it --
        if (PlayerPrefs.HasKey("mVol"))
        {
            LoadVolume();
        }
        else 
        {
            SetMusicVol();
            SetSFXVol();
        }
    }

    // -- Makes and sets the slider to be able to change the audio of the music --
    public void SetMusicVol()
    {
        float vol = musicSlide.value;

        // -- The "music" is a parameter added in Audio Mixer tabs --
        daMixer.SetFloat("music", Mathf.Log10(vol)*20);

        // -- Stores the value of the slider in the keyname "mVol" --
        PlayerPrefs.SetFloat("mVol", vol);
    }

    public void SetSFXVol()
    {
        float vol = SFXSlide.value;

        // -- The "music" is a parameter added in Audio Mixer tabs --
        daMixer.SetFloat("SFX", Mathf.Log10(vol) * 20);

        // -- Stores the value of the slider in the keyname "mVol" --
        PlayerPrefs.SetFloat("SFXVol", vol);
    }

    private void LoadVolume()
    {
        /** -- Equats the variable "musicSlide" & "SFXVol" value to the value that was stored --
        -- with the "mVol" & "SFXVol" keyname to this method -- **/
        musicSlide.value = PlayerPrefs.GetFloat("mVol");
        SFXSlide.value = PlayerPrefs.GetFloat("SFXVol");

        // -- Just calls the method --
        SetMusicVol();
        SetSFXVol();
    }
    #endregion
}
