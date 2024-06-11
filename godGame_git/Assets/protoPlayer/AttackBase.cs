using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//—ñ‹“Œ^‚Ì’è‹`
public enum PartsList
{
    _Head,
    _Arm,
    _Leg
}

public class AttackBase : MonoBehaviour
{
    [SerializeField] public PartsList partsList;  // ‚Ç‚Ì•”ˆÊ‚É‚Â‚¢‚Ä‚¢‚é‚©‚ðŠi”[

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
