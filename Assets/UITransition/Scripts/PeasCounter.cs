using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeasCounter : MonoBehaviour {

    #region Global Variables

    private Image img;
    private static Material mat;
    //Speed used to be 0.23
    private const float Speed = 0.25f;
    private const string C = "_Cutoff";
    private static float getFloat;

    //special variables for this script (swipe reset and stuff)
    private bool reset = true;


    #endregion

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
        mat = img.material;
        SetCutOff(0);
    }

    private void Update()
    {


        //Debug.Log("has swiped: " + ...
        if (PlayerMovement.swiped)
        {
            if (reset)
            {
                SetCutOff(1);
                reset = false;
            }

            getFloat = mat.GetFloat(C);
            SetCutOff(getFloat -= Speed * Time.deltaTime);    
        }

        if (getFloat <= 0 && !reset)
        {
            reset = true;
        }

        /*if (PlayerMovement.deltaTouch == 0)
        {
            SetCutOff(1);
        }*/
    }

    #region private methods

    /*
     * Set the _Cutoff value in the transition shader.
     * @params : floating point number
     *
     */

    private static void SetCutOff(float f)
    {
        mat.SetFloat(C, f);
    }

    #endregion
}
