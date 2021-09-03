using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public bool isVulnerable = true;
    private Transform personTransform;
    [SerializeField] private float bottomMargin = -2.5f;
    void Start()
    {
        personTransform = this.transform;
    }

    public void СhangeOfLocation(float locX_coordintate)
    {
        personTransform.position = new Vector2(locX_coordintate, bottomMargin);
    }


    public void Death()
    {
        Debug.Log("Death");
    }

}
