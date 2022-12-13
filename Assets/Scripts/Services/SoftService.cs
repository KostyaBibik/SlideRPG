namespace Services
{
    public class SoftService
    {
        private int _softValue;

        public void AddSoft(int softValue)
        {
            _softValue += softValue;
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
    }
}