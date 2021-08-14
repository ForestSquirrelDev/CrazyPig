using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace CrazyPig.Player
{
    public class UniversalInput
    {
        public float HorizontalAxisMobile { get; private set; }
        public float VerticalAxisMobile { get; private set; }
        public float HorizontalAxisEditor { get; private set; }
        public float VerticalAxisEditor { get; private set; }

        public void HandleInput()
        {
            HorizontalAxisMobile = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            VerticalAxisMobile = CrossPlatformInputManager.GetAxisRaw("Vertical");

            HorizontalAxisEditor = Input.GetAxisRaw("Horizontal");
            VerticalAxisEditor = Input.GetAxisRaw("Vertical");
        }
    }
}
