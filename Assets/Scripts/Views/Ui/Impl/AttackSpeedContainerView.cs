using Services;
using UnityEngine;
using Zenject;

namespace Views.Ui.Impl
{
    public class AttackSpeedContainerView : UpgradeContainerView
    {
        [Inject] private SoftService _softService;
        [Inject] private PlayerParametersService _playerParametersService;
        
        private void Start()
        {
            upgradeBtn.onClick.AddListener(OnBtnClick);
            descriptionCurrentValue.text = _playerParametersService.AttackSpeed.ToString();
            costUpgradeTxt.text = costUpgradeValue.ToString();
        }

        private void OnBtnClick()
        {
            if (_softService.TrySpendSoft(costUpgradeValue))
            {
                costUpgradeValue += Random.Range(1, 2);
                costUpgradeTxt.text = costUpgradeValue.ToString();
                _playerParametersService.RaiseAttackSpeed(Random.Range(0.05f, 0.1f));
                descriptionCurrentValue.text = _playerParametersService.AttackDamage.ToString();
            }
        }
    }
}