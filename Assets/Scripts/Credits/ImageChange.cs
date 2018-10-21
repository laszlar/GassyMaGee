using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    //Booleans
    public bool swapImage;

    //scripts
    Image finalImage;
    Color alphaValue;

	void Start ()
    {
        swapImage = false;

        //access the final image script
        finalImage = GetComponent<Image>();

        alphaValue = finalImage.color;

        //make sure that the alpha of the image is 0
        if (alphaValue.a > 0f)
            alphaValue.a = 0f;

        finalImage.color = alphaValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
