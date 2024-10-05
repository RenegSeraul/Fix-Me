using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("======== Audio Source ========")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("======== Audio Clips ========")]
    public AudioClip background;
    public AudioClip elevatorsound;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Starts to load in Prefs
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

        if (!PlayerPrefs.HasKey("mutez"))
        {
            PlayerPrefs.SetInt("mutez", 0);
            LoadM();
        }
        else
        {
            LoadM();
        }

        if (!PlayerPrefs.HasKey("SFXz"))
        {
            PlayerPrefs.SetInt("SFXz", 0);
            LoadSFX();
        }
        else
        {
            LoadSFX();
        }
    }

    // Plays the audio clip
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    #region -- Toggling On/Off Sounds --
    // -- Toggle on/off sound/SFX --
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;

        // -- Literally saves the changes to player prefs --
        SaveM();
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;

        // -- Literally saves the changes to player prefs --
        SaveSFX();
    }
    #endregion

    #region -- Saves preferences --
    private void LoadM()
    {
        // -- Checks if muted is equals to 1, if not 1, the it will set to false --
        musicSource.mute = PlayerPrefs.GetInt("mutez") == 1;
    }

    private void SaveM()
    {
        // -- Short hand if else | if "muted" variable is true or false | Stores the value to the prefs paramenter "mutez" --
        PlayerPrefs.SetInt("mutez", musicSource.mute ? 1 : 0);
    }

    private void LoadSFX()
    {
        // -- Checks if muted is equals to 1, if not 1, the it will set to false --
        sfxSource.mute = PlayerPrefs.GetInt("SFXz") == 1;
    }

    private void SaveSFX()
    {
        // -- Short hand if else | if "SFXz" variable is true or false | Stores the value to the prefs paramenter "SFXz" --
        PlayerPrefs.SetInt("SFXz", sfxSource.mute ? 1 : 0);
    }
    #endregion
}
