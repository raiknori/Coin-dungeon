using UnityEditor.Search;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    [SerializeField] AudioManager audioManager;

    public override void InstallBindings()
    {
        Container.Bind<AudioManager>().FromInstance(audioManager);
    }

}
