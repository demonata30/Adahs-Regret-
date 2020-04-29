using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacterAn : MonoBehaviour
{
    #region VARiABLES

    [Header("Referenced Variables")]
    [SerializeField]
    GameObject objectTofollow;

    [Header("Development values")]
    Vector2 myDistanceToFllowerDifference;

    #endregion

    #region UNITY CALLBACKS
    private void Start()
    {
        CalculateDifference();
    }
    private void LateUpdate()
    {
        FollowObject();
    }
    #endregion

    #region PRIVATE MEHTODS
    private void CalculateDifference()
    {
        myDistanceToFllowerDifference = gameObject.transform.position - objectTofollow.transform.position;
    }
    private void FollowObject()
    {

        gameObject.transform.position = new Vector3(objectTofollow.transform.position.x + myDistanceToFllowerDifference.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    #endregion
}
