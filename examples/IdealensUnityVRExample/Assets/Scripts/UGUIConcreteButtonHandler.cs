using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UGUIConcreteButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private string originalText;
	private bool isGazedAt;
	private Text label;

	private void Awake () {
		label = GetComponentInChildren<Text> ();
		originalText = label.text;

        IVR.IVRK2Event.TouchEvent_HomeButton += HandleHomeButtonPress;
        IVR.IVRK2Event.TouchEvent_onSingleTap += HandleSingleTap;
        IVR.IVRK2Event.TouchEvent_onPress += HandlePress;
        IVR.IVRK2Event.TouchEvent_onLongPress += HandleLongPress;
        IVR.IVRK2Event.TouchEvent_onPressDown += HandlePressDown;
        IVR.IVRK2Event.TouchEvent_OnPressUp += HandlePressUp;
        IVR.IVRK2Event.TouchEvent_onScroll += HandleScroll;
        IVR.IVRK2Event.TouchEvent_onSwipe += HandleSwipe;
    }

	private void SetTextIfGazedAt(string text) {
		if (isGazedAt) {
			label.text = text;
		}
	}

	/* Pointer Events */

	public void OnPointerEnter(PointerEventData eventData) {
		isGazedAt = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		isGazedAt = false;
	}

    /* Idealens event handlers */

    public void HandleHomeButtonPress()
    {
        SetTextIfGazedAt("Pressed Home Button");
    }

    public void HandleSingleTap()
    {

    }

    public void HandlePress(Vector2 delta)
    {

    }

    public void HandleLongPress()
    {
        SetTextIfGazedAt("Long Pressed");
    }

    public void HandlePressDown()
    {
        SetTextIfGazedAt("Pressed Down");
    }

    public void HandlePressUp()
    {
        SetTextIfGazedAt("Pressed Up");
    }

    public void HandleScroll(Vector2 delta)
    {
        if (Math.Abs(delta.x) > 10)
        {
            SetTextIfGazedAt("Scrolled");
        }
    }

    public void HandleSwipe(SwipEnum delta)
    {
        if (delta == SwipEnum.MOVE_FOWRAD || delta == SwipEnum.MOVE_BACK)
        {
            SetTextIfGazedAt("Swiped");
        }
    }
}
