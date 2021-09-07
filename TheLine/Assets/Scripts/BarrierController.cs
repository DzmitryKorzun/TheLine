using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using System;

[RequireComponent(typeof(PoolObject))]

public class BarrierController : MonoBehaviour
{
    [Inject] private PersonController person;
    [SerializeField] private float distanceMoving = 12;
    private Transform transformBarrier;
    public Action deactivationRowEvent;
    public float speed = 12;
    
    private void Awake()
    {
        transformBarrier = GetComponent<Transform>();
    }


    private void Start()
    {
        transformBarrier.DOLocalMoveY((transformBarrier.localPosition.y - distanceMoving), speed).SetEase(Ease.Linear).OnComplete(deactivateBarrier);
    }

  

    private void OnEnable()
    {
        transformBarrier.DOLocalMoveY((transformBarrier.localPosition.y - distanceMoving), speed).SetEase(Ease.Linear).OnComplete(deactivateBarrier);
    }


    private void deactivateBarrier()
    {

        this.gameObject.SetActive(false);
    }

}
