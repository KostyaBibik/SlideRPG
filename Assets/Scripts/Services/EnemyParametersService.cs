using Db;

namespace Services
{
    public class EnemyParametersService
    {
        private int _attackDamage;
        private int _health;
        private float _attackSpeed;
        private readonly float _speedMoving;
        
        public int AttackDamage => _attackDamage;
        public int Health => _health;
        public float AttackSpeed => _attackSpeed;
        public float SpeedMoving => _speedMoving;
        
        public EnemyParametersService(EnemyConfigSettings configSettings)
        {
            _attackDamage = configSettings.Attack;
            _health = configSettings.Health;
            _attackSpeed = configSettings.AttackSpeed;
            _speedMoving = configSettings.SpeedMoving;
        }

        public void RaiseAttackDamage(int raiseValue)
        {
            _attackDamage += raiseValue;
        }
        
        public void RaiseHealth(int raiseValue)
        {
            _health += raiseValue;
        }
        
        public void RaiseAttackSpeed(int raiseValue)
        {
            _attackSpeed += raiseValue;
        }
    }
}