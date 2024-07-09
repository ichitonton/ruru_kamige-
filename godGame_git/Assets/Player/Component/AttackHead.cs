using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AttackHead : AttackBase
{

    // Start is called before the first frame update
    void Start()
    {
        SetGeneratMethod();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        generateBases[0].Action(transform.position, transform.root.forward);
    }
}
