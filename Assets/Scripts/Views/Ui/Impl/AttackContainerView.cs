
using Services;
using UnityEngine;
using Zenject;

namespace Views.Ui.Impl
{
    public class AttackContainerView : UpgradeContainerView
    {
        [Inject] private SoftService _softService;
        [Inject] private PlayerParametersService _playerParametersService;
        
        private void Start()
        {
            upgradeBtn.onClick.AddListener(OnBtnClick);
            descriptionCurrentValue.text = _playerParametersService.AttackDamage.ToString();
            costUpgradeTxt.text = costUpgradeValue.ToString();
        }

        private void OnBtnClick()
        {
            if (_softService.TrySpendSoft(costUpgradeValue))
            {
                costUpgradeValue += Random.Range(1, 2);
                costUpgradeTxt.text = costUpgradeValue.ToString();
                _playerParametersService.RaiseAttackDamage(Random.Range(1, 3));
                descriptionCurrentValue.text = _playerParametersService.AttackDamage.ToString();
            }
        }
    }
}