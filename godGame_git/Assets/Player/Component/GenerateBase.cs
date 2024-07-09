using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBase : MonoBehaviour
{
    protected float Angle;
    protected int NumberOf;
    [SerializeField] protected GameObject generateObject;
    virtual public void Action(Vector3 position, Vector3 forward) { }
    public void SetGenerateObject(GameObject prefab, float angle, int numberOf) 
    {
        generateObject = prefab;
        Angle = angle;
        NumberOf = numberOf;
    }
}
