using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameObjectConcreteIOnHoverHandler : MonoBehaviour, IOnHoverHandler {
    private Color originalColor;
    private bool isHovered;

    // Use this for initialization
    void Start () {
        originalColor = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
	    if (isHovered)
        {
            GetComponent<Renderer>().material.color = Color.green;
        } else
        {
            GetComponent<Renderer>().material.color = originalColor;
        }

        isHovered = false;
	}

    public void OnHover(IVRRayPointerEventData eventData)
    {
        isHovered = true;
    }
}
