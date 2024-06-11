using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    public void TradeParts(ref GameObject a, ref GameObject b)
    {
        print("a");
        // Transform proto = a.transform;
        //proto.parent = null;
        a.transform.GetChild(0).transform.parent = b.transform;
        b.transform.GetChild(0).transform.parent = a.transform;
        print("b");

        //a.transform.GetChild(0).gameObject.GetComponent<AttackBase>().SetPartsList(a.GetComponent<PartInfo>().GetPartsList());
        //b.transform.GetChild(0).gameObject.GetComponent<AttackBase>().SetPartsList(b.GetComponent<PartInfo>().GetPartsList());

        PartsList p = a.transform.GetChild(0).gameObject.GetComponent<AttackBase>().partsList;
        a.transform.GetChild(0).gameObject.GetComponent<AttackBase>().partsList = b.transform.GetChild(0).gameObject.GetComponent<AttackBase>().partsList;
        b.transform.GetChild(0).gameObject.GetComponent<AttackBase>().partsList = p;

        Vector3 proto = a.transform.GetChild(0).transform.position;
        a.transform.GetChild(0).transform.position = b.transform.GetChild(0).transform.position;
        b.transform.GetChild(0).transform.position = proto;

    }
}
