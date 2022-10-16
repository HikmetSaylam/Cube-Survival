using Assets.Scripts.GeneralScripts;
using UnityEngine;

namespace GeneralScripts
{
    public class PlayerMovement : MonoSigleton<PlayerMovement>
    {
        private Rigidbody2D _rigidbody2D;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    
        private void FixedUpdate()
        {
            if(ControlInput.Instance.GetJumpOnClicked())
                PlayerJump.Instance.LetItJump();
            _rigidbody2D.velocity =
                GameManager.Instance.MovePlayer(ControlInput.Instance.GetHorizontal(), PlayerJump.Instance.Jump());

        }
    }
}
