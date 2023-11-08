using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    /// <summary>
    /// 改為固定巡邏路線，或是預生成路線
    /// </summary>
    public class EnemyIdleState : EnemyState
    {
        private Vector3 targetPos;
        private Vector3 direction;

        public EnemyIdleState(EnemyBase _enemyBase, EnemyStateMachine _enemyStateMachine) : base(_enemyBase, _enemyStateMachine)
        {
        }

        public override void EnterState() 
        {
            base.EnterState();

            targetPos = GetRandomPointCircle();
        }

        public override void FrameUpdate() 
        {
            base.FrameUpdate();

            if(enemyBase.IsInChaseRange)
            {
                enemyBase.StateMachine.ChangeState(enemyBase.ChaseState);
            }

            direction = (targetPos - enemyBase.transform.position).normalized;

            enemyBase.SetVelocity(direction * enemyBase.PatrolSpeed);

            if((enemyBase.transform.position - targetPos).sqrMagnitude <= .5) // 向量轉長度
            {
                targetPos = GetRandomPointCircle();
            }

        }

        public override void AnimTriggerEvent(EnemyBase.AnimTriggerTypes _triggerTypes) {}
    
        private Vector3 GetRandomPointCircle()
        {
            return enemyBase.transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * enemyBase.PatrolMoveRange;
        }
    }
}
