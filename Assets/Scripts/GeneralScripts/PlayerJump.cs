using GeneralScripts;
using UnityEngine;

namespace Assets.Scripts.GeneralScripts
{
    public class PlayerJump : MonoSigleton<PlayerJump>
    {
        [SerializeField] [Range(0,2)] private float gravityForce;
        [SerializeField] [Range(0,10)] private float jumpForce;
        [SerializeReference] [Range(0, 2)] private float pushBackForce;
        private float _tmpGravityForce;
        private float _tmpJumpForce;
        private bool _isItJumping;
        private bool _isItOnGround;
        private bool _isItPushedBack;

        private void Start()
        {
            _isItOnGround = true;
            _isItJumping = false;
        }

        public float Jump()
        {
            switch (!_isItJumping)
            {
                case true when !_isItOnGround:
                    _tmpGravityForce += gravityForce;
                    return -_tmpGravityForce;
                case true when _isItOnGround:
                    return 0;
            }
            _tmpGravityForce += gravityForce;
            _tmpJumpForce = jumpForce - _tmpGravityForce;
            if (_isItPushedBack)
                return -_tmpGravityForce / pushBackForce;
            return _tmpJumpForce;

        }
        public void LetItJump()
        {
            _isItJumping = true;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.CompareTag("PushBackPoint"))
            {
                _isItPushedBack = true;
            }
            if(!col.collider.tag.Equals("Ground")) return;
            _tmpGravityForce = 0;
            _tmpJumpForce = 0;
            _isItJumping = false;
            _isItOnGround = true;
            _isItPushedBack = false;
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            if(!col.collider.tag.Equals("Ground")) return;
            _isItOnGround = false;
        }
    }
}
