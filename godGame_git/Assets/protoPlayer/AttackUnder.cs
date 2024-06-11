using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUnder : AttackBase
{
    [SerializeField] GameObject SlashPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        switch (partsList)
        {
            case PartsList._Head:
                break;
            case PartsList._Arm:
                break;
            case PartsList._Leg:
                Instantiate(SlashPrefab, transform.parent.transform.position + (transform.root.transform.forward * 1.0f), new Quaternion(0,0,0,0));
                break;
        }
    }
}
