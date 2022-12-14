using System;
using Db;
using Signals;
using Zenject;

namespace Services
{
    public class SoftService : IInitializable, IDisposable
    {
        private int _softValue;
        private readonly SignalBus _signalBus;
        private readonly ProgressConfigSettings _progressConfigSettings;

        public int CurrentSoft => _softValue;
        public event Action<int> onUpdateSoft;
        
        public SoftService(
            SignalBus signalBus,
            ProgressConfigSettings progressConfigSettings
            )
        {
            _signalBus = signalBus;
            _progressConfigSettings = progressConfigSettings;
        }
        
        public void AddSoft(int softValue)
        {
            _softValue += softValue;
            onUpdateSoft?.Invoke(_softValue);
        }

        public bool TrySpendSoft(int spendValue)
        {
            if (_softValue >= spendValue)
            {
                _softValue -= spendValue;
                return true;
            }
            
            return false;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<KillEnemySignal>(OnKillEnemy);
        }

        public void Dispose()
        {
            _signalBus.Subscribe<KillEnemySignal>(OnKillEnemy);
        }

        private void OnKillEnemy(KillEnemySignal killEnemySignal)
        {
            AddSoft(_progressConfigSettings.SoftValueOnKillEnemy);
        }
    }
}