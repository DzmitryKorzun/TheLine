using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MyGameIntaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PoolObject>().AsTransient();
    }
}
