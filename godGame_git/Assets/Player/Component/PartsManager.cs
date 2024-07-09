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
    protected PartsList NowParts;   // ���ǂ̕��ʂɂ��Ă��邩

    protected SkinnedMeshRenderer smr;

    [SerializeField, Header("���ɂ������̃��b�V��")] Mesh headMesh;
    [SerializeField, Header("��ɂ������̃��b�V��")] Mesh handMesh;
    [SerializeField, Header("�r�ɂ������̃��b�V��")] Mesh legMesh;

    [SerializeField, Header("���ɂ������̃}�e���A��")] Material headMaterial;
    [SerializeField, Header("��ɂ������̃}�e���A��")] Material handMaterial;
    [SerializeField, Header("�r�ɂ������̃}�e���A��")] Material legMaterial;

    [SerializeField, Header("���ɂ������̂��炵��"),Compact]     protected Vector3 headOfset;
    [SerializeField, Header("���ɂ������̊p�x"), Compact] protected Vector3 headAngle;

    [SerializeField, Header("����ɂ������̂��炵��"), Compact]   protected Vector3 leftHandOfset;
    [SerializeField, Header("����ɂ������̊p�x"), Compact] protected Vector3 leftHandAngle;

    [SerializeField, Header("�E��ɂ������̂��炵��"), Compact]   protected Vector3 rightHandOfset;
    [SerializeField, Header("�E��ɂ������̊p�x"), Compact] protected Vector3 rightHandAngle;

    [SerializeField, Header("�r�ɂ������̂��炵��"), Compact]     protected Vector3 legOfset;
    [SerializeField, Header("�r�ɂ������̊p�x"), Compact] protected Vector3 legAngle;

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
