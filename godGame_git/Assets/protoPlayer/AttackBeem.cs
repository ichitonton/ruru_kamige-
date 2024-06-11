using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeem : AttackBase
{
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        print("KI");
        //partsList = transform.parent.GetComponent<PartInfo>().GetPartsList();
        partsList = PartsList._Head;
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
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 0.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 1.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 2.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 3.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 4.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 5.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                Instantiate(bulletPrefab, transform.parent.transform.position + (transform.root.transform.forward * 6.5f), new Quaternion(90,90,90,90)).GetComponent<BulletManajar>().SetHead(transform.root.transform.forward);
                break;
            case PartsList._Arm:
                Instantiate(bulletPrefab, transform.parent.transform.position, new Quaternion(90, 0, 90, 0)).GetComponent<BulletManajar>().SetBeem(transform.root.transform.forward);
                break;
            case PartsList._Leg:
                break;
        }
    }
}

