using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BladePartsManager : PartsManazar
{

    // Start is called before the first frame update
    void Start()
    {
        Attacks[0] = GetComponent<AttackHead>();
        Attacks[1] = GetComponent<AttackHand>();
        Attacks[2] = GetComponent<AttackLeg>();

        smr = GetComponent<SkinnedMeshRenderer>();

        SetMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action()
    {
        Attacks[(int)NowParts].Attack();
    }
}
