using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class AttackSlash : AttackBase
{
    [SerializeField] GameObject SlashPrefab;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        print("KI");
        partsList = PartsList._Arm;

        //transform.parent.gameObject.GetComponentInParent<PartInfo>().GetPartsList();

        //if (transform.parent.gameObject.TryGetComponent<PartInfo>(out var pi))
        //{
            //print(pi.GetPartsList());
        //}

        //if(

        //print(partsList);
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
                pos = transform.parent.transform.position + (transform.root.transform.forward * 0.5f);
                Instantiate(SlashPrefab, pos + transform.root.transform.right * 2.5f, (transform.root.transform.rotation));
                Instantiate(SlashPrefab, pos + (-transform.root.transform.right) * 2.5f, (transform.root.transform.rotation));
                break;
            case PartsList._Arm:
                Instantiate(SlashPrefab, transform.parent.transform.position + (transform.root.transform.forward * 0.5f), transform.rotation);
                break;
            case PartsList._Leg:
                Instantiate(SlashPrefab, transform.parent.transform.position + (transform.root.transform.forward * 0.5f), transform.rotation).GetComponent<SlashManajar>().SetRotateMove();
                break;
        }
    }
}
