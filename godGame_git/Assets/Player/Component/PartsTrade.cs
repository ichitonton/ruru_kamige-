using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsTrede : MonoBehaviour
{
    public void Trade(ref PartsManazar a, ref PartsManazar b)
    {
        Transform parent = a.GetParent();
        a.SetParent(b.GetParent());
        b.SetParent(parent);

        PartsList prats =  a.GetPartsList();
        a.SetPartsList(b.GetPartsList());
        b.SetPartsList(prats);

        a.SetPosition();
        b.SetPosition();

        a.SetAngle(); 
        b.SetAngle();

        a.SetMesh();
        b.SetMesh();
    }
}
