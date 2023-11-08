using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class EnemyChaseState : EnemyState
    {
        private Transform playerTransform;

        public EnemyChaseState(EnemyBase _enemyBase, EnemyStateMachine _enemyStateMachine) : base(_enemyBase, _enemyStateMachine)
        {
            playerTransform = enemyBase.PlayerTransform;
        }

        public override void FrameUpdate() 
        {
            base.FrameUpdate();

            Vector2 _moveDirection = (playerTransform.position - enemyBase.transform.position).normalized;

            enemyBase.SetVelocity(_moveDirection * enemyBase.ChasingSpeed);

            if(enemyBase.IsInAttackRange)
            {
                enemyBase.StateMachine.ChangeState(enemyBase.AttackState);
            }
        }
    }
}
