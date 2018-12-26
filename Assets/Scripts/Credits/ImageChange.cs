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

        //make sure that the alpha of the image is 0
        if (alphaValue.a > 0f)
            alphaValue.a = 0f;    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //set that the float value is recognized as the color for the image
        alphaValue = finalImage.color;

        //boolean that changes the alpha value for the image (shows the image)
        if (swapImage)
        {
            alphaValue.a = 255.0f;

            //Implements the a value to the color, so that it switches images.
            finalImage.color = alphaValue;
        }
    }
}
