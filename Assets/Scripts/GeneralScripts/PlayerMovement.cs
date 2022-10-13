using Assets.Scripts.GeneralScripts;
using UnityEngine;

namespace GeneralScripts
{
    public class PlayerMovement : MonoSigleton<PlayerMovement>
    {
        [SerializeField] [Range(1,100)] private int soaringValue;
        [SerializeField] [Range(0, 1)] private float flyingValue;
        [SerializeField] [Range(0, 20)] private int speed;
        [SerializeField] [Range(1, 20)] private int dashForce;
        private Rigidbody2D _rigidbody2D;
        private float _yAxis;
        private float _xAxis;
    
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        private void FixedUpdate()
        {
            _yAxis = PlayerJump.Instance.Jump();
            _xAxis = ControlInput.Instance.GetHorizontal();
            if (ControlInput.Instance.GetSoarOnClicked() && _yAxis < 0)
            {
                _yAxis /=soaringValue ;
            }

            if (ControlInput.Instance.GetFlyOnClicked()&&_yAxis<0)
            {
                _yAxis *= -flyingValue;
            }

            _yAxis = Mathf.Clamp(_yAxis, -2.5f, 3);
            Debug.Log(_yAxis);
            if (ControlInput.Instance.GetDashOnClicked())
            {
                _xAxis *= dashForce;
            }
            if(ControlInput.Instance.GetJumpOnClicked())
                PlayerJump.Instance.LetItJump();
            _rigidbody2D.velocity = new Vector2(_xAxis*speed,_yAxis*speed);
            
        }
    }
}
