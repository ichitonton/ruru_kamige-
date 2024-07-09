using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackHand : AttackBase
{

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
