using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3(0, 0, -10);
    }
}
