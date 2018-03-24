using System;
using Framework.Data;
using UnityEngine;

namespace Framework
{
    public static class Extensions
    {
        public static void SetParameter(this Animator animator, AnimatorParameter parameter)
        {
            var paramId = Animator.StringToHash(parameter.name);

            switch (parameter.type) {
                case AnimatorParameter.AnimatorParamType.Int:
                    animator.SetInteger(paramId, parameter.intValue);
                    break;
                case AnimatorParameter.AnimatorParamType.Float:
                    animator.SetFloat(paramId, parameter.floatValue);
                    break;
                case AnimatorParameter.AnimatorParamType.Bool:
                    animator.SetBool(paramId, parameter.boolValue);
                    break;
                case AnimatorParameter.AnimatorParamType.Trigger:
                    animator.SetTrigger(paramId);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}