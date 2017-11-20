using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeansCounter : MonoBehaviour
{

    #region Global Variables

    private Image _img;
    private static Material _mat;
    private const float Speed = 0.75f;
    private const string C = "_Cutoff";
    private static float _getFloat;

    #endregion

    private void Start()
    {
        _img = gameObject.GetComponent<Image>();
        _mat = _img.material;
        SetCutOff(0);
    }

    private void Update()
    {
        //Debug.Log("IsJumping: " + PlayerMovement.IsJumping);
        if (PlayerMovement.IsJumping)
        {
            _getFloat = _mat.GetFloat(C);
            SetCutOff(_getFloat += Speed * Time.deltaTime);
        }
        if (!PlayerMovement.IsJumping)
        {
            SetCutOff(0);
        }
    }

    #region private methods

    /*
     * Set the _Cutoff value in the transition shader.
     * @params : floating point number
     *
     */

    private static void SetCutOff(float f)
    {
        _mat.SetFloat(C, f);
    }

    #endregion
}
