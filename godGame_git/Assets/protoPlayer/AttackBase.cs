using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�񋓌^�̒�`
public enum PartsList
{
    _Head,
    _Arm,
    _Leg
}

public class AttackBase : MonoBehaviour
{
    [SerializeField] public PartsList partsList;  // �ǂ̕��ʂɂ��Ă��邩���i�[

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
