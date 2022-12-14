using Db;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = nameof(GameSettingsInstaller),
        menuName = "Installers/" + nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private PlayerConfigSettings playerSettings;
        [SerializeField] private EnemyConfigSettings enemyConfigSettings;
        [SerializeField] private ProgressConfigSettings progressConfigSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(playerSettings);
            Container.BindInstance(enemyConfigSettings);
            Container.BindInstance(progressConfigSettings);
        }
    }
}