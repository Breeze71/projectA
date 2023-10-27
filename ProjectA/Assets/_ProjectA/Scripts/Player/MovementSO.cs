using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using V.Tool.JuicyFeeling;

namespace V
{
    [CreateAssetMenu(menuName = "ScriptableObject/MovementSO", order = 0)]
    public class MovementSO : ScriptableObject
    {
        public float WalkSpeed;
        public float SprintSpeed;
        public float MoveLerp = 10f;

        public SquashStretchSO walkSquash;
        public SquashStretchSO sprintSquash;
    }
}
