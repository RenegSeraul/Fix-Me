using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpens : MonoBehaviour
{

    public GameObject MaxPane;

        public void OpenMaxPane()
        {
            if (MaxPane != null)
            {
                Animator an = MaxPane.GetComponent<Animator>();
                if (an != null)
                {
                    bool OpenT = an.GetBool("Open");

                    an.SetBool("Open", !OpenT);
                }
            }
        }

}
