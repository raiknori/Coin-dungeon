using UnityEngine;
using Zenject;

public class CoinModuleInstaller:MonoInstaller
{
    [SerializeField] CoinFlipping coinFlipping;
    [SerializeField] CoinLoader coinLoader;
    [SerializeField] CoinAnimation coinAnimation;

    public override void InstallBindings()
    {
       Container.Bind<CoinFlipping>().FromInstance(coinFlipping);
       Container.Bind<CoinLoader>().FromInstance(coinLoader);
       Container.Bind<CoinAnimation>().FromInstance(coinAnimation);
       
    }
}
