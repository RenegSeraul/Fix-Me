using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{

    public static bool twoIsLocked = true;
    public static bool threeIsLocked = true;
    public static bool fourIsLocked = true;
    public static bool fiveIsLocked = true;

    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;

    public Image Level2;
    public Sprite unlockedTwo;

    public Image Level3;
    public Sprite unlockedThree;

    public Image Level4;
    public Sprite unlockedFour;

    public Image Level5;
    public Sprite unlockedFive;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (twoIsLocked)
        {
        }
        else if (twoIsLocked == false)
        {
            Level2.sprite = unlockedTwo;
        }

        else if (threeIsLocked == false)
        {
            Level3.sprite = unlockedThree;
        }
        else if (fourIsLocked == false)
        {
            Level4.sprite = unlockedFour;
        }
        else if (fiveIsLocked == false)
        {
            Level5.sprite = unlockedFive;
        }
    }

    public void onClick()
    {



    }
}
