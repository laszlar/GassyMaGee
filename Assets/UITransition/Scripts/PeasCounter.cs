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
    private static float calcFloat;

    //special variables for this script (swipe reset and stuff)
    private bool reset = true;
    private float timer = 0f;

    #endregion

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
        mat = img.material;
        SetCutOff(0);
    }

    private void Update()
    {

        if (PlayerMovement.fingerMoved)
        {
            if (reset)
            {
                SetCutOff(1);
                reset = false;
            }
            getFloat = mat.GetFloat(C);
            getFloat -= Speed * Time.deltaTime;
            SetCutOff(getFloat);
        }

        /*
        //Debug.Log("has swiped: " + ...
        if (PlayerMovement.startTimer)
        {
            if (reset)
            {
                SetCutOff(1);
                reset = false;       
            }

            getFloat = mat.GetFloat(C);
            SetCutOff(getFloat -= Speed * Time.deltaTime);
        }
        
        //fall back setting to 
        if (getFloat <= 0.01f)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                reset = true;
                SetCutOff(0);
                timer = 0f;
            }
            
        }*/
       
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
