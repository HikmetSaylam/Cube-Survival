using GeneralScripts;
using UnityEngine;

namespace Assets.Scripts.GeneralScripts
{
    public class ControlInput : MonoSigleton<ControlInput>
    {
        private bool _jumpOnClicked;
        private bool _dashOnClicked;
        private bool _soarOnClicked;
        private bool _flyOnClicked;

        public float GetHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }
        public bool GetJumpOnClicked()
        {
            return Input.GetKey(KeyCode.Space);
        }

        public bool GetDashOnClicked()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }

        public bool GetSoarOnClicked()
        {
            return Input.GetKey(KeyCode.E);
        }

        public bool GetFlyOnClicked()
        {
            return Input.GetKey(KeyCode.Q);
        }
    }
}
