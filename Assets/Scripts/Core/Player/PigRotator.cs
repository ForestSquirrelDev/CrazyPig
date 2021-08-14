using UnityEngine;

namespace CrazyPig.Player
{
    public class PigRotator
    {
        private readonly SpriteContainer sprites;
        private UniversalInput input;
        private SpriteRenderer spriteRenderer;

        public PigRotator
            (UniversalInput input, SpriteRenderer spriteRenderer, SpriteContainer sprites)
        {
            this.spriteRenderer = spriteRenderer;
            this.input = input;
            this.sprites = sprites;
        }

        public void HandleRotation()
        {
            if((input.VerticalAxisMobile > 0
                || input.VerticalAxisEditor > 0)
                && spriteRenderer.sprite != sprites.RotationTop)
                    spriteRenderer.sprite = sprites.RotationTop;

            if((input.VerticalAxisMobile < 0
                || input.VerticalAxisEditor < 0)
                && spriteRenderer.sprite != sprites.RotationBottom)
                    spriteRenderer.sprite = sprites.RotationBottom;

            if((input.HorizontalAxisMobile > 0
                || input.HorizontalAxisEditor > 0)
                && spriteRenderer.sprite != sprites.RotationRight)
                    spriteRenderer.sprite = sprites.RotationRight;

            if((input.HorizontalAxisMobile < 0
                || input.HorizontalAxisEditor < 0)
                && spriteRenderer.sprite != sprites.RotationLeft)
                    spriteRenderer.sprite = sprites.RotationLeft;
        }
    }
}
