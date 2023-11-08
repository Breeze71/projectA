using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class EnemyAttackState : EnemyState
    {
        private Transform playerTransform;

        private float shootCDTimer;
        private float shootCDTimerMax = 2f;
        private float exitTimer;
        private float exitTimerMax = 3f;
        private float distanceToCountExit = 6f;
        private float bulletSpeed = 5f;

        public EnemyAttackState(EnemyBase _enemyBase, EnemyStateMachine _enemyStateMachine) : base(_enemyBase, _enemyStateMachine)
        {
            playerTransform = enemyBase.PlayerTransform;
        }
        public override void EnterState() 
        {
            base.EnterState();

            enemyBase.SetVelocity(Vector2.zero);
        }
        public override void ExitState() {}
        public override void FrameUpdate() 
        {
            base.FrameUpdate();

            if(shootCDTimer > shootCDTimerMax)
            {
                shootCDTimer = 0f;
                Vector2 _dir =  (playerTransform.position - enemyBase.transform.position).normalized;

                Rigidbody2D _bullet = GameObject.Instantiate(enemyBase.BulletPrefab, enemyBase.transform.position, Quaternion.identity);
                _bullet.velocity = _dir * bulletSpeed;
            }   

            // 待修改
            if(Vector2.Distance(playerTransform.position, enemyBase.transform.position) >= distanceToCountExit)
            {
                exitTimer += Time.deltaTime;

                if(exitTimer > exitTimerMax)
                {
                    enemyBase.StateMachine.ChangeState(enemyBase.ChaseState);
                }
            }
            else
            {
                exitTimer = 0f;
            }

            shootCDTimer += Time.deltaTime;         
        }
    }


}
