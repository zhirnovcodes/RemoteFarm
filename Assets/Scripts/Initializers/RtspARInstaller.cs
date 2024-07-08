using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;

public class RtspARInstaller : Installer<RtspARInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<LoadingCurtainView>().AsSingle();
        //Container.Bind<>().FromInstance().AsSingle();
    }
}
