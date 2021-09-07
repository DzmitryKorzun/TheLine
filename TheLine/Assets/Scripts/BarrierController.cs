using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;
using System;

[RequireComponent(typeof(PoolObject))]

public class BarrierController : MonoBehaviour
{
    [Inject]
    private PersonController person;

    public Action deactivationRowEvent;
    public float speed = 6;
    Sequence mySequence;
    private void Awake()
    {        
        mySequence = DOTween.Sequence();

    }

    public void GetPersonReference(PersonController refPerson)
    {
        person = refPerson;
        person.OnStartGame += ContinueGame;
        person.OnPauseGame += StopMove;
    }

    private void Start()
    {
        mySequence.Append(this.transform.DOMoveY(-6, speed).OnComplete(deactivateBarrier).SetEase(Ease.Linear)); 
    }

    private void StopMove()
    {        
        mySequence.Pause();
    }

    private void ContinueGame()
    {
        mySequence.Play();
    }

    private void deactivateBarrier()
    {
        deactivationRowEvent?.Invoke();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        
    }

}
