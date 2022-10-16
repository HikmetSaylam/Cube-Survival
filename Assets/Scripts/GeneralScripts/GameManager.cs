using Assets.Scripts.GeneralScripts;
using UnityEngine;

namespace GeneralScripts
{
    public class GameManager : MonoSigleton<GameManager>
    {
        [SerializeField] [Range(1,100)] private int flowingValue;
        [SerializeField] [Range(0, 1)] private float flyingValue;
        [SerializeField] [Range(0, 20)] private int speed;
        [SerializeField] [Range(1, 20)] private int dashForce;
        private Vector2 _playerMomentVector;

        public Vector2 MovePlayer(float xAxis,float yAxis)
        {
            if (ControlInput.Instance.GetSoarOnClicked() && yAxis < 0&&StaminaBar.Instance.GetHasStamina())
            {
                StaminaBar.Instance.SpendSoar();
                yAxis /=flowingValue ;
            }
            
            if (ControlInput.Instance.GetFlyOnClicked()&&yAxis<0&&StaminaBar.Instance.GetHasStamina())
            {
                StaminaBar.Instance.SpendFly();
                yAxis *= -flyingValue;
            }
            
            if (ControlInput.Instance.GetDashOnClicked()&&StaminaBar.Instance.GetHasStamina())
            {
                StaminaBar.Instance.SpendDash();
                xAxis *= dashForce;
            }
            
            yAxis = Mathf.Clamp(yAxis, -2.5f, 3);
            _playerMomentVector.x = xAxis * speed;
            _playerMomentVector.y = yAxis * speed;
            return _playerMomentVector;
        }
    }
}
