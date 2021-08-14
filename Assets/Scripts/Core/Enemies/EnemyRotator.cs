using System;
using UnityEngine;
using UnityEngine.AI;

namespace CrazyPig.Enemies
{
    /// <summary>
    /// Changes enemy sprites on movement.
    /// </summary>
    public class EnemyRotator : IDisposable
    {
        private readonly NavMeshAgent agent;
        private readonly EnemyLOS sight;
        private readonly SpriteRenderer spriteRenderer;
        private readonly SpriteContainer firstSet;
        private readonly SpriteContainer secondSet;

        private SpriteContainer currentSprites;

        public EnemyRotator
            (NavMeshAgent agent, EnemyLOS sight, SpriteRenderer spriteRenderer,  SpriteContainer firstSet, SpriteContainer secondSet)
        {
            this.agent = agent;
            this.sight = sight;
            this.spriteRenderer = spriteRenderer;
            this.firstSet = firstSet;
            this.secondSet = secondSet;
            currentSprites = firstSet;

            this.sight.OnPlayerSpotted += SetAngry;
            this.sight.OnPlayerLost += SetCalm;
        }

        ~EnemyRotator() => Dispose();

        public void Dispose()
        {
            this.sight.OnPlayerSpotted -= SetAngry;
            this.sight.OnPlayerLost -= SetCalm;
        }

        public void RotateEnemy()
        {
            if (agent.velocity.x < -0.9f
                && spriteRenderer.sprite != currentSprites.RotationLeft)
                    spriteRenderer.sprite = currentSprites.RotationLeft;

            if (agent.velocity.x > 0.9f
                && spriteRenderer.sprite != currentSprites.RotationRight)
                    spriteRenderer.sprite = currentSprites.RotationRight;

            if (agent.velocity.y < -0.9f
                && spriteRenderer.sprite != currentSprites.RotationBottom)
                    spriteRenderer.sprite = currentSprites.RotationBottom;

            if (agent.velocity.y > 0.9f
                && spriteRenderer.sprite != currentSprites.RotationTop)
                    spriteRenderer.sprite = currentSprites.RotationTop;
        }

        private void SetAngry(Transform target)
        {
            if(currentSprites != secondSet)
                currentSprites = secondSet;
        }

        private void SetCalm() => currentSprites = firstSet;
    }
}
