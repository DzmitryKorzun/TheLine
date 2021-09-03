using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PoolObject))]

public class BarrierController : MonoBehaviour
{
    [Inject]
    private PersonController person;
    private PoolObject _poolObject;

    private void OnTriggerEnter(Collider collider)
    {
        if (person.Equals(collider))
        {
            if (person.isVulnerable)
            {
                person.Death();
            }
        }

        if (collider.gameObject.name == "DeadZone")
        {
            _poolObject.ReturnToPool();
        }

    }



}
