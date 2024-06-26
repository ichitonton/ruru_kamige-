using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//列挙型の定義
public enum PartsList
{
    _Head,
    _Arm,
    _Leg
}

public class AttackBase : MonoBehaviour
{
    [SerializeField] public PartsList partsList;  // どの部位についているかを格納

    protected int partsNum;

    public virtual void Attack() { }

    public void SetPartsList(PartsList pl)
    {
        partsList = pl;
    }

    public void SetPartsNum(int pn)
    {
        partsNum = pn;
    }
}
