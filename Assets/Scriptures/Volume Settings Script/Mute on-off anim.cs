using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsPlayer : MonoBehaviour
{
    //public AudioSource src;
    //public AudioClip clip;
    public Button button;
    public Sprite playImage;
    public Sprite pauseImage;

    private bool muted = false;

    #region -- Main Functions --
    // -- Gets the saved preference and loads it --
    void Start()
    {

        if (!PlayerPrefs.HasKey("mutez"))
        {
            PlayerPrefs.SetInt("mutez", 0);
            Load();
        }
        else
        {
            Load();
        }

        ButtonIconUpdates();
    }

    // -- Mute on/off music sounds --
    public void ToggleM()
    {
        AudioManager.instance.ToggleMusic();
        muted = !muted;

        ButtonIconUpdates();
    }


    // -- Updates the Icon appearance --
    private void ButtonIconUpdates()
    {
        if (muted == false)
        {
            button.image.sprite = playImage;
        }
        else
        {
            button.image.sprite = pauseImage;
        }
    }
    #endregion

    #region -- Player Prefs Load/Save | Only gets the state for Icon Updates --
    // -- Save & Loads Player Prefs --
    private void Load()
    {
        // -- Checks if muted is equals to 1, if not 1, the it will set to false --
        muted = PlayerPrefs.GetInt("mutez") == 1;
    }
    #endregion

    #region -- older functions | Outdated --
    //// Start is called before the first frame update
    //void Start()
    //{
    //    //src.clip = clip;
    //    //src.Play();

    //    if (!PlayerPrefs.HasKey("mutez"))
    //    {
    //        PlayerPrefs.SetInt("mutez", 0);
    //        Load();
    //    }
    //    else
    //    {
    //        Load();
    //    }
    //    ButtonIconUpdates();
    //    AudioListener.pause = muted;
    //}
    //public void PauseorPlay()
    //{
    //    //if (src.isPlaying)
    //    if (muted == false)
    //    {
    //        muted = true;
    //        //src.clip = clip;
    //        //src.Pause();
    //        AudioListener.pause = true;
    //        button.image.sprite = pauseImage;
    //    }
    //    else
    //    {
    //        muted = false;;
    //        //src.clip = clip;
    //        //src.UnPause();
    //        AudioListener.pause = false;
    //        button.image.sprite = playImage;
    //    }
    //    // -- Literally saves the changes of the global varuabke --
    //    Save();
    //    // -- Calls this function --
    //    ButtonIconUpdates();
    //}

    //// -- Updates the Icon appearance --
    //private void ButtonIconUpdates()
    //{
    //    if (muted == false)
    //    {
    //        button.image.sprite = playImage;
    //    }
    //    else
    //    {
    //        button.image.sprite = pauseImage;
    //    }
    //} 

    //private void Load()
    //{
    //    // -- Checks if muted is equals to 1, if not 1, the it will set to false --
    //    muted = PlayerPrefs.GetInt("mutez") == 1;
    //}
    //private void Save()
    //{
    //    // -- Short hand if else | if "muted" variable is true or false | Stores the value to the prefs paramenter "mutez" --
    //    PlayerPrefs.SetInt("mutez", muted ? 1 : 0); 
    //}
    #endregion
}
