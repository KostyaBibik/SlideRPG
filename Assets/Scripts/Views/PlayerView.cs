using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        private int _health;

        public void ApplyDamage(int damageValue)
        {
            Debug.Log("GetDamage : "+damageValue);
            _health -= damageValue;
        }
    }
}