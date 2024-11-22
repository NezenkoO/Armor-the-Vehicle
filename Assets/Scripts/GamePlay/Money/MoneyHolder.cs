using UnityEngine;
using UnityEngine.Events;

namespace GamePlay
{
    public class MoneyHolder : MonoBehaviour
    {
        public event UnityAction<int> BalanceChanged;
        public int Value => _money.Value;
        public bool HasMoney => _money.Value > 0;

        private MoneyBalance _money;

        private void OnEnable()
        {
            _money = new MoneyBalance();
            _money.Load();

            _money.Changed += OnMoneyChanged;
        }

        private void OnDisable()
        {
            _money.Changed -= OnMoneyChanged;
            _money.Save();
        }

        public void AddMoney(int value)
        {
            _money.Add(value);
        }

        public void SpendMoney(int value)
        {
            _money.Spend(value);
        }

        private void OnMoneyChanged()
        {
            BalanceChanged?.Invoke(_money.Value);
            _money.Save();
        }
    }
}