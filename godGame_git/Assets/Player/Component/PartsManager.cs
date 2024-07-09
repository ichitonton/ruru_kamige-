using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public enum PartsList
{
    Head = 0,
    Hand,
    Leg
};

[RequireComponent(typeof(AttackHead))]
[RequireComponent(typeof(AttackHand))]
[RequireComponent(typeof(AttackLeg))]

[RequireComponent(typeof(SkinnedMeshRenderer))]

public class PartsManazar : MonoBehaviour
{
    protected PartsList NowParts;   // 今どの部位についているか

    protected SkinnedMeshRenderer smr;

    [SerializeField, Header("頭につけた時のメッシュ")] Mesh headMesh;
    [SerializeField, Header("手につけた時のメッシュ")] Mesh handMesh;
    [SerializeField, Header("脚につけた時のメッシュ")] Mesh legMesh;

    [SerializeField, Header("頭につけた時のマテリアル")] Material headMaterial;
    [SerializeField, Header("手につけた時のマテリアル")] Material handMaterial;
    [SerializeField, Header("脚につけた時のマテリアル")] Material legMaterial;

    [SerializeField, Header("頭につけた時のずらし量"),Compact]     protected Vector3 headOfset;
    [SerializeField, Header("頭につけた時の角度"), Compact] protected Vector3 headAngle;

    [SerializeField, Header("左手につけた時のずらし量"), Compact]   protected Vector3 leftHandOfset;
    [SerializeField, Header("左手につけた時の角度"), Compact] protected Vector3 leftHandAngle;

    [SerializeField, Header("右手につけた時のずらし量"), Compact]   protected Vector3 rightHandOfset;
    [SerializeField, Header("右手につけた時の角度"), Compact] protected Vector3 rightHandAngle;

    [SerializeField, Header("脚につけた時のずらし量"), Compact]     protected Vector3 legOfset;
    [SerializeField, Header("脚につけた時の角度"), Compact] protected Vector3 legAngle;

    protected AttackBase[] Attacks = new AttackBase[3];

    virtual public void Action() {}

    public void SetPartsList(PartsList parts) { NowParts = parts; }
    public virtual PartsList GetPartsList() { return NowParts; }

    public void SetParent(Transform parent) { transform.parent = parent; }
    public Transform GetParent() { return transform.parent; }

    public void SetPosition() { 
        switch (NowParts)
        {
            case PartsList.Head:
                transform.localPosition = headOfset;
                break;
            case PartsList.Hand:
                if(transform.parent.name == "LeftHand")
                    transform.localPosition = leftHandOfset;
                else
                    transform.localPosition = rightHandOfset;
                break;
            case PartsList.Leg:
                transform.localPosition = legOfset;
                break;
        }
    }

    public void SetAngle()
    {
        switch (NowParts)
        {
            case PartsList.Head:
                transform.eulerAngles = headAngle;
                break;
            case PartsList.Hand:
                if (transform.parent.name == "LeftHand")
                    transform.eulerAngles = leftHandAngle;
                else
                    transform.eulerAngles = rightHandAngle;
                break;
            case PartsList.Leg:
                transform.eulerAngles = legAngle;
                break;
        }
    }

    public void SetMesh()
    {
        switch (NowParts)
        {
            case PartsList.Head:
                smr.sharedMesh = headMesh;
                break;
            case PartsList.Hand:
                smr.sharedMesh = handMesh;
                break;
            case PartsList.Leg:
                smr.sharedMesh = legMesh;
                break;
        }
    }
}
