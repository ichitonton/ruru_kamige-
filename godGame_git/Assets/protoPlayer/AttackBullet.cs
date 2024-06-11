using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBullet : AttackBase
{
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //partsList = transform.parent.GetComponent<PartInfo>().GetPartsList();
        //partsList = PartsList._Head;
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
                Instantiate(bulletPrefab, transform.parent.transform.position, new Quaternion(0, 0, 0, 0)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                break;
            case PartsList._Arm:
                Instantiate(bulletPrefab, transform.parent.transform.position, new Quaternion(0,0,0,0)).GetComponent<BulletManajar>().SetDirection(transform.root.transform.forward);
                break;
            case PartsList._Leg:
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 2.0f), new Quaternion(0, 0, 0, 0)).GetComponent<BulletManajar>().SetHead(transform.root.transform.up);
                break;
        }
    }
}
