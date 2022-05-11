using UnityEngine;
using System.Collections;
using Microsoft.MixedReality.Toolkit.Input;

[RequireComponent(typeof(BoxCollider))]

public class DragObject : MonoBehaviour, IMixedRealityPointerHandler
{
    private Vector3 screenPoint; 
    private Vector3 offset;
    private float _lockedYPosition;
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        //screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // I removed this line to prevent centring 
        _lockedYPosition = screenPoint.y;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData) { }
    public void OnPointerDragged(MixedRealityPointerEventData eventData) 
    {
        eventData.Use();
    }
    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        Cursor.visible = true;
    }
}