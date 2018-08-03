using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]
public class GameObjectConcreteButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	private Color originalColor;
	private bool isGazedAt;
	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer> ();
		originalColor = meshRenderer.material.color;

        IVR.IVRK2Event.TouchEvent_HomeButton += HandleHomeButtonPress;
        IVR.IVRK2Event.TouchEvent_onSingleTap += HandleSingleTap;
        IVR.IVRK2Event.TouchEvent_onPress += HandlePress;
        IVR.IVRK2Event.TouchEvent_onLongPress += HandleLongPress;
        IVR.IVRK2Event.TouchEvent_onPressDown += HandlePressDown;
        IVR.IVRK2Event.TouchEvent_OnPressUp += HandlePressUp;
        IVR.IVRK2Event.TouchEvent_onScroll += HandleScroll;
        IVR.IVRK2Event.TouchEvent_onSwipe += HandleSwipe;
    }

    private void SetColorIfGazedAt(Color color) {
		if (isGazedAt) {
			meshRenderer.material.color = color;
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

    public void HandleHomeButtonPress() {
        SetColorIfGazedAt(Color.red);
    }

    public void HandleSingleTap() {
        
    }

    public void HandlePress(Vector2 delta) {
        
    }

    public void HandleLongPress() {
        SetColorIfGazedAt(Color.cyan);
    }

    public void HandlePressDown() {
        SetColorIfGazedAt(Color.green);
    }

    public void HandlePressUp() {
        SetColorIfGazedAt(originalColor);
    }

    /* Call when finger moves vertically or horizontally. We have chosen to only allow scroll on the vertical axis */
    /* Please note the property delta.x is mapped to the vertical axis while the property delta.y is mapped to the horizontal axis */

    public void HandleScroll(Vector2 delta) {
        if (Math.Abs(delta.x) > 10)
        {
            SetColorIfGazedAt(Color.grey);
        }
    }

    /* Call when finger moves over 20% of touchpad. We have chosen to only allow swipes on the horizontal axis */

    public void HandleSwipe(SwipEnum delta) {
        if (delta == SwipEnum.MOVE_FOWRAD || delta == SwipEnum.MOVE_BACK)
        {
            SetColorIfGazedAt(Color.white);
        }
    }
}
