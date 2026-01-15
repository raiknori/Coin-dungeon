using UnityEngine;
using Zenject;

public class ProgressionModuleInstaller:MonoInstaller
{
    [SerializeField] StoryCore story;
    [SerializeField] GameCore game;
    [SerializeField] Restart restart;
    [SerializeField] HealthCore healthCore;
    [SerializeField] Ending ending;
    [SerializeField] FloorCore floorCore;
    [SerializeField] GoldCore goldCore;

    public override void InstallBindings()
    {
        Container.Bind<StoryCore>().FromInstance(story);
        Container.Bind<GameCore>().FromInstance(game);
        Container.Bind<Restart>().FromInstance(restart);
        Container.Bind<HealthCore>().FromInstance(healthCore);
        Container.Bind<Ending>().FromInstance(ending);
        Container.Bind<FloorCore>().FromInstance(floorCore);
        Container.Bind<GoldCore>().FromInstance(goldCore);
    }
}
