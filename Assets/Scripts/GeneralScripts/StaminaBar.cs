using GeneralScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GeneralScripts
{
    public class StaminaBar : MonoSigleton<StaminaBar>
    {
        [SerializeField] private Image staminaBar;
        [SerializeField] [Range(0,1)] private float flowSpent;
        [SerializeField] [Range(0,1)] private float flySpent;
        [SerializeField] [Range(0,1)] private float DashSpent;
        [SerializeField] [Range(0,1)] private float staminaIncreaseValue;
        private int _maxStamina;
        private float _currentStamina;
        private bool _doesHasStamina;

        private void Start()
        {
            _maxStamina = 100;
            _currentStamina = _maxStamina;
        }

        private void FixedUpdate()
        {
            _currentStamina+=staminaIncreaseValue;
            _currentStamina = Mathf.Clamp(_currentStamina, 0, 100);
            staminaBar.fillAmount = _currentStamina / _maxStamina;
        }

        public bool GetHasStamina()
        {
            _doesHasStamina = !(_currentStamina <= 0);
            return _doesHasStamina;
        }

        public void SpendSoar()
        {
            _currentStamina -= flowSpent;
        }

        public void SpendFly()
        {
            _currentStamina -= flySpent;
        }

        public void SpendDash()
        {
            _currentStamina -= DashSpent;
        }
    }
}

