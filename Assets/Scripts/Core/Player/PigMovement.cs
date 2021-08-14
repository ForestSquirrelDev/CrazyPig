using UnityEngine;

namespace CrazyPig.Player
{
    public class PigMovement
    {
        private readonly UniversalInput input;
        private readonly MovementSettings movementSettings;
        private readonly Rigidbody2D rb;
        private readonly bool useEditorMovement;

        public PigMovement
            (UniversalInput input, Rigidbody2D rigidbody, MovementSettings moveSett, bool isEditor)
        {
            this.useEditorMovement = isEditor;
            this.input = input;
            this.rb = rigidbody;
            this.movementSettings = moveSett;
        }

        public void HandleMovement()
        {
            if(!useEditorMovement)
                rb.velocity = new Vector2(input.HorizontalAxisMobile,
                                           input.VerticalAxisMobile) 
                                           * movementSettings.MovementSpeed;
            else
                rb.velocity = new Vector2(input.HorizontalAxisEditor,
                                          input.VerticalAxisEditor)
                                          * movementSettings.MovementSpeed;
        }
    }
}
