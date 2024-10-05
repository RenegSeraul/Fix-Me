using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSFXonoff : MonoBehaviour
{
    public Button button;
    public Sprite playImage;
    public Sprite pauseImage;

    private bool mutedSFX = false;

    // -- Gets the saved preference and loads it --
    void Start()
    {

        if (!PlayerPrefs.HasKey("SFXz"))
        {
            PlayerPrefs.SetInt("SFXz", 0);
            Load2();
        }
        else
        {
            Load2();
        }

        ButtonIconUpdSFX();
    }

    // -- Mute on/off SFX --
    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
        mutedSFX = !mutedSFX;

        ButtonIconUpdSFX();
    }

    // -- Updates the Icon appearance --
    private void ButtonIconUpdSFX()
    {
        if (mutedSFX == false)
        {
            button.image.sprite = playImage;
        }
        else
        {
            button.image.sprite = pauseImage;
        }
    }

    #region -- Player Prefs Load/Save | Only gets the state for Icon Updates --
    private void Load2()
    {
        // -- Checks if muted is equals to 1, if not 1, the it will set to false --
        mutedSFX = PlayerPrefs.GetInt("SFXz") == 1;
    }
    #endregion
}
