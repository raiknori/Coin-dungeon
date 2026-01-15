using UnityEngine;
using Zenject;

public class GameplayModuleInstaller:MonoInstaller
{
    [SerializeField] AttackCore attackCore;
    [SerializeField] Grid grid;
    [SerializeField] ImpactCore impactCore;
    [SerializeField] MovementCore movementCore;
    [SerializeField] TurnCore turnCore;

    public override void InstallBindings()
    {
        Container.Bind<AttackCore>().FromInstance(attackCore);
        Container.Bind<Grid>().FromInstance(grid);
        Container.Bind<ImpactCore>().FromInstance(impactCore);
        Container.Bind<MovementCore>().FromInstance(movementCore);
        Container.Bind<TurnCore>().FromInstance(turnCore);
    }
}