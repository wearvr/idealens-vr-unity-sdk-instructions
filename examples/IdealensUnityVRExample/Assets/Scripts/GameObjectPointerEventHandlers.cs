using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GameObjectPointerEventHandlers : MonoBehaviour {
    private bool isGazedAt;
	private bool isClicked;
    private bool isScrolled;
    private bool isDragged;
    private Color originalColor;

	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer> ();
		originalColor = meshRenderer.material.color;
	}

    private void SetMeshColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    private void Update() {
        if (isGazedAt) {
            if (isClicked) {
                SetMeshColor(Color.red);
            } else if (isScrolled) {
                SetMeshColor(Color.grey);
            } else if (isDragged) {
                SetMeshColor(Color.magenta); ;
            } else {
                /* Never happens because isDragged is true whenever isGazedAt is true */
                SetMeshColor(Color.green);
            }
		} else {
            SetMeshColor(originalColor);
		}
	}

	/* Pointer Events */

	public void HandlePointerEnter() {
		isGazedAt = true;
	}

	public void HandlePointerExit() {
		isGazedAt = false;
		isClicked = false;
        isScrolled = false;
        isDragged = false;
    }

	public void HandlePointerClick() {
		isClicked = true;
	}

    public void OnScroll()
    {
        isScrolled = true;
    }

    public void OnDrag()
    {
        isDragged = true;
    }
}
