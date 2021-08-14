using UnityEngine;
using UnityEngine.AI;
using System;

namespace CrazyPig.Enemies
{
    public class EnemyAI : IDisposable
    {
        private readonly RandomWalkPoints walkPoints;
        private readonly NavMeshAgent agent;
        private readonly EnemyHP HP;
        private readonly EnemyLOS sight;
        private readonly AISettings aiSettings;

        private Transform playerTransform;
        private bool chasingPlayer = false;

        public EnemyAI
            (RandomWalkPoints walkPoints, NavMeshAgent agent, EnemyHP HP, AISettings aiSettings, EnemyLOS sight)
        {
            this.walkPoints = walkPoints;
            this.agent = agent;
            this.HP = HP;
            this.aiSettings = aiSettings;
            this.sight = sight;
      
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            agent.speed = aiSettings.DefaultSpeed;

            HP.OnDeathOccured += InterruptPathfinding;
            sight.OnPlayerSpotted += ChasePlayer;
            sight.OnPlayerLost += StopChasingPlayer;
        }

        ~EnemyAI() => Dispose();

        public void Dispose()
        {
            HP.OnDeathOccured -= InterruptPathfinding;
            sight.OnPlayerSpotted -= ChasePlayer;
            sight.OnPlayerLost -= StopChasingPlayer;
        }

        public void CheckPathCompletion()
        {
            if (!agent.pathPending && !chasingPlayer)
            {
                if (agent.remainingDistance - 0.5f <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude < 0.9f)
                    {
                        GetNewPath();
                    }
                }
            }
        }

        public void GetNewPath()
        {
            Transform target;

            if (!chasingPlayer)
            {
                target = walkPoints.GetRandomPoint();
                agent.SetDestination((Vector2)target.position);
            }
            else
            {
                target = this.playerTransform;
                agent.SetDestination((Vector2)target.position);
            }
        }

        private void ChasePlayer(Transform target)
        {
            if (this.playerTransform == null)
                this.playerTransform = target;

            if(!chasingPlayer && agent.speed != aiSettings.RageSpeed)
            {
                chasingPlayer = true;
                agent.speed = aiSettings.RageSpeed;
            }
            GetNewPath();
        }

        private void StopChasingPlayer()
        {
            chasingPlayer = false;
            GetNewPath();
            agent.speed = aiSettings.DefaultSpeed;
        }

        private void InterruptPathfinding() => agent.isStopped = true;
    }
}
