using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V
{
    public class EnemyBase : MonoBehaviour, IDamagable, IEnemyMoveable, ITriggerCheckable
    {
        [field : SerializeField] public int maxHealth {get; set ;}
        public HealthSystem HealthSystem {get; set;}
        public Rigidbody2D Rb {get; set;}
        public bool IsFacingRight {get; set;} = true;

        public bool IsInChaseRange {get; set;}
        public bool IsInAttackRange {get; set;}
        
        #region FSM
        public EnemyStateMachine StateMachine{get; set;}

        public EnemyIdleState IdleState {get; set;}
        public EnemyAttackState AttackState {get; set;}
        public EnemyChaseState ChaseState {get; set;}
        #endregion

        #region FSM - var
        public Transform PlayerTransform;
        public Rigidbody2D BulletPrefab;
        public float PatrolMoveRange = 5f;
        public float PatrolSpeed = 1f;

        public float ChasingSpeed = 5f;
        #endregion

        #region Unity
        private void Awake() 
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

            StateMachine = new EnemyStateMachine();

            IdleState = new EnemyIdleState(this, StateMachine);    
            AttackState = new EnemyAttackState(this, StateMachine);   
            ChaseState = new EnemyChaseState(this, StateMachine);   
        }
        private void Start() 
        {
            HealthSystem = new HealthSystem(maxHealth);

            Rb = GetComponent<Rigidbody2D>();    

            StateMachine.Initalize(IdleState);
        }
        
        private void Update() 
        {
            StateMachine.CurrentEnemyState.FrameUpdate();    
        }
        private void FixedUpdate() 
        {
            StateMachine.CurrentEnemyState.PhysicsUpdate();
        }
        #endregion

        #region Health / Die
        public void TakeDamage(int _damageAmount)
        {
            HealthSystem.TakeDamage(_damageAmount);

            if(HealthSystem.GetHealthAmount() <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            
        }
        #endregion

        #region Movement
        public void SetVelocity(Vector2 _velocity)
        {
            Rb.velocity = _velocity;
            CheckFacing(_velocity);
        }

        public void CheckFacing(Vector2 _velocity)
        {
            if(IsFacingRight && _velocity.x < 0f)
            {
                Flip();
            }
            else if(!IsFacingRight && _velocity.x > 0)
            {
                Flip();
            }
        }
        private void Flip()
        {
            Vector3 _rotate = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(_rotate);
            IsFacingRight = !IsFacingRight;                  
        }
        #endregion
    
        public void SetChasingStatus(bool _IsInChaseRange)
        {
            IsInChaseRange = _IsInChaseRange;
        }

        public void SetAttackStatus(bool _IsInAttackRange)
        {
            IsInAttackRange = _IsInAttackRange;
        }


        #region Anim Trigger
        private void AnimTriggerEvent(AnimTriggerTypes _triggerTypes)
        {
            StateMachine.CurrentEnemyState.AnimTriggerEvent(_triggerTypes);
        }

        public enum AnimTriggerTypes
        {
            EnemyDamaged,
            PlayFootStepSound,
        }
        #endregion
    }
}
