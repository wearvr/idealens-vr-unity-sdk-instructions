using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(MeshRenderer))]
public class GameObjectConcretePointerHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IScrollHandler, IDragHandler {
	private Color originalColor;
	private MeshRenderer meshRenderer;

	private void Awake() {
		meshRenderer = GetComponent<MeshRenderer> ();
		originalColor = meshRenderer.material.color;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		meshRenderer.material.color = Color.green;
	}

	public void OnPointerExit(PointerEventData eventData) {
		meshRenderer.material.color = originalColor;
	}

	public void OnPointerClick(PointerEventData eventData) {
		meshRenderer.material.color = Color.red;
	}

    public void OnScroll(PointerEventData eventData) {
        meshRenderer.material.color = Color.grey;
    }

    public void OnDrag(PointerEventData eventData) {
        meshRenderer.material.color = Color.magenta;
    }
}
