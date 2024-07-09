using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTurn : MonoBehaviour
{

    [SerializeField, Header("aaa")] float a;

    public void Turn(Vector3 direction)
    {
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * 10f);
    }
}
