using Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace Views.Ui
{
    public class PanelsHandler : MonoBehaviour
    {
        [SerializeField] private TMP_Text softTxt;
        [Inject] private SoftService _softService;

        private void Start()
        {
            UpdateSoftText(_softService.CurrentSoft);
            _softService.onUpdateSoft += UpdateSoftText;
        }

        private void UpdateSoftText(int newValue)
        {
            softTxt.text = $"coins : {newValue.ToString()}";
        }
    }
}