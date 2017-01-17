using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Texture2D inventoryIcon;
    public string inventoryLabel;
    public bool activatePaint;
    public bool activateParachute;

    [SerializeField]
    private GameObject paint;
    [SerializeField]
    private GameObject parachute;

    private void Start()
    {
        paint = GameObject.Find("paint");
        parachute = GameObject.Find("parachute");
    }

    //activate powerups
	public virtual void Activate ()
    {
        if (activatePaint)
        {
            paint.gameObject.SetActive(true);
        }

        if (activateParachute)
        {
            parachute.gameObject.SetActive(true);
        }
    }
	
    //deactivate powerups
	public virtual void Deactivate ()
    {
        if (activatePaint)
        {
            paint.gameObject.SetActive(false);
        }

        if (activateParachute)
        {
            parachute.gameObject.SetActive(false);
        }
    }
}
