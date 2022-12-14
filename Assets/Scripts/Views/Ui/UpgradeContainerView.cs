using Db.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Ui
{
    public class UpgradeContainerView : MonoBehaviour
    {
        public EUpgradeType upgradeType;

        public int costUpgradeValue;
        
        public TMP_Text costUpgradeTxt;
        public TMP_Text descriptionCurrentValue;
        public Button upgradeBtn;
    }
}