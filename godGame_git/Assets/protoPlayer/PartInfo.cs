using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartInfo : MonoBehaviour
{
    [SerializeField] PartsList partsList;
    private int partsNum;

    private void Start()
    {
        partsNum = (int)partsList;
    }

    
    public PartsList GetPartsList()
    {
        return partsList;
    }
    
}
