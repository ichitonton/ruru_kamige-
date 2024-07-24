using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSlashCollider : GenerateBase
{
    public override void Action(Vector3 position, Vector3 forward)
    {
        Instantiate(generateObject,position,Quaternion.identity).GetComponent<BulletManager>().transform.parent = transform;
    }
}
