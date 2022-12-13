using Db;

namespace Services
{
    public class PlayerParametersService
    {
        private int _attackDamage;
        private int _health;
        private int _currentHealth;
        private float _attackSpeed;
        private readonly float _speedMovingBullet;
        
        public int AttackDamage => _attackDamage;
        public int Health => _currentHealth;
        public float AttackSpeed => _attackSpeed;
        public float SpeedMovingBullet => _speedMovingBullet;

        public PlayerParametersService(PlayerConfigSettings configSettings)
        {
            _attackDamage = configSettings.Attack;
            _health = configSettings.Health;
            _attackSpeed = configSettings.AttackSpeed;
            _speedMovingBullet = configSettings.SpeedMovingBullet;
            _currentHealth = _health;
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
        
        public void ApplyDamage(int damageValue)
        {
            _currentHealth -= damageValue;
        }
    }
}