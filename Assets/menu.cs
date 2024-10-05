using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Menu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        //SceneManager.LoadSceneAsync("Level 1");
        LoaderistBar.Insta.LoadScene(sceneName);
    }
}