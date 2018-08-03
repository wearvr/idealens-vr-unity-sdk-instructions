using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UGUIConcreteIOnHoverHandler : MonoBehaviour, IOnHoverHandler
{

    private string originalText;
    private bool isHovered;

    // Use this for initialization
    void Start()
    {
        originalText = gameObject.GetComponentInChildren<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovered)
        {
            gameObject.GetComponentInChildren<Text>().text = "Hovered";
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = originalText;
        }

        isHovered = false;
    }

    public void OnHover(IVRRayPointerEventData eventData)
    {
        gameObject.GetComponentInChildren<Text>().text = "Hovered";
    }
}
