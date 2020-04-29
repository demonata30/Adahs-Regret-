using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationsAn : MonoBehaviour
{
    #region VARIABLES

    [Header("Referenced variables")]
    [SerializeField]
    Animator animator;

    [Header("Development variables")]
    const string runningBoolValue = "IsRunning";
    const string takeoffBoolValue = "IsTakingOff";
    const string falingDownBoolValue = "IsFallingDown";
    #endregion

    #region PUBLIC METHODS

    public void SetRunning( bool isRunning)
    {
        animator.SetBool(runningBoolValue, isRunning);  
    }
    public void SetTakeOff(bool isTakingoff)
    {
        animator.SetBool(takeoffBoolValue, isTakingoff);

        if(isTakingoff)
            ResetOtherAnimations(takeoffBoolValue);
    }
    public void FalingDown(bool isFalingDown)
    {
        animator.SetBool(falingDownBoolValue, isFalingDown);

        if(isFalingDown)
            ResetOtherAnimations(falingDownBoolValue);
    }
    public void ResetOtherAnimations(string currentWorkingAnimation)
    {
        animator.SetBool(runningBoolValue, currentWorkingAnimation==runningBoolValue);
        animator.SetBool(takeoffBoolValue, currentWorkingAnimation == takeoffBoolValue);
        animator.SetBool(falingDownBoolValue, currentWorkingAnimation == falingDownBoolValue);
    }
    #endregion
}
