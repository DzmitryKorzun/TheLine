using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
public class LineControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Inject]
    private PersonController personController;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var x = cam.ScreenToWorldPoint(eventData.pressPosition).x;
        personController.СhangeOfLocation(x);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }



    

}
