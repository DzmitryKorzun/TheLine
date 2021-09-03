using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
[RequireComponent(typeof(PoolObject))]

public class BarrierController : MonoBehaviour
{
    [Inject]
    private PersonController person;

    public delegate void deactivationRow();
    public event deactivationRow deactivationRowEvent;

    private void Start()
    {
        this.transform.DOMoveY(-6, 6).OnComplete(deactivateBarrier).SetEase(Ease.Linear); ;
    }

    private void deactivateBarrier()
    {
        deactivationRowEvent?.Invoke();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (person.gameObject.Equals(collision.gameObject))
        {
            if (person.isVulnerable)
            {
                person.Death();
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
        Debug.Log(collision);
    }

}
