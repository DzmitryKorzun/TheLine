using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class LineControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Inject] private PersonController personController;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        var x = cam.ScreenToWorldPoint(eventData.position).x;
        personController.СhangeOfLocation(x);
    }
}
