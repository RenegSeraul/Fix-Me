using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Threading.Tasks;

public class LoaderistBar : MonoBehaviour
{
    public static LoaderistBar Insta;

    #region -- variables --
    [Header("Vars")]
    [SerializeField] private GameObject _loadCanvas;
    [SerializeField] private Image _bar;
    #endregion

    #region -- functionality --
    // Makes this instance active throughout the game
    private void Awake()
    {
        if (Insta == null)
        {
            Insta = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Makes this load the scenes
    public async void LoadScene(string sceneN)
    {
        var scene = SceneManager.LoadSceneAsync(sceneN);
        scene.allowSceneActivation = false;

        _loadCanvas.SetActive(true);

        // Makes this load the loading bar
        do
        {
            //await Task.Delay(100);
            _bar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(100);
        // Allowing the scene to activate or unload
        scene.allowSceneActivation = true;
        _loadCanvas.SetActive(false);
    }
    
    #endregion
}
