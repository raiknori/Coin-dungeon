using UnityEngine;
using Zenject;

public class ButtonModuleInstaller:MonoInstaller
{
    [SerializeField] ButtonAnimation buttonAnimation;
    [SerializeField] ButtonLoader buttonLoader;
    public override void InstallBindings()
    {
        Container.Bind<ButtonLoader>().FromInstance(buttonLoader);
        Container.Bind<ButtonAnimation>().FromInstance(buttonAnimation);   
    }
}
