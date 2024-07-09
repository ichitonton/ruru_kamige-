using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public enum GeneratMethod
{
    RadialHorizontal = 0,
    RadialVertical,
    SlashCollider,
};

[System.Serializable]
public class AttackInformtion
{
    // “®“I‚É•\Ž¦‚µ‚½‚¢‚¯‚Ç‚â‚è•û‚í‚©‚ç‚ñ
    [SerializeField] public GameObject _GeneratObject;
    [SerializeField] public GeneratMethod _GeneratMethod;

    [SerializeField] public float _Angle;
    [SerializeField] public int _NumberOf;
};

[System.Serializable]
public class MultiStageAttack
{
    [SerializeField] public AttackInformtion[] _AttackInformtion;
};

public class AttackBase : MonoBehaviour
{
    [SerializeField] protected MultiStageAttack multiStageSetting;
    protected int MultiStageNum;
    protected int NowStageNum = 0;
    protected GenerateBase[] generateBases = new GenerateBase[9];

    protected void SetGeneratMethod()
    {
        MultiStageNum = multiStageSetting._AttackInformtion.Length;
        
        for (int i = 0; i < MultiStageNum; ++i) {
            switch (multiStageSetting._AttackInformtion[i]._GeneratMethod) {
                case GeneratMethod.RadialHorizontal:
                    generateBases[i] = gameObject.AddComponent<GenerateRadialHorizontal>();
                    break;
                case GeneratMethod.RadialVertical:
                    generateBases[i] = gameObject.AddComponent<GenerateRadialVertical>();
                    break;
                case GeneratMethod.SlashCollider:
                    generateBases[i] = gameObject.AddComponent<GenerateSlashCollider>();
                    break;
                default:
                    break;
            }
            generateBases[i].SetGenerateObject(multiStageSetting._AttackInformtion[i]._GeneratObject, multiStageSetting._AttackInformtion[i]._Angle, multiStageSetting._AttackInformtion[i]._NumberOf);
        }
        
    }

    virtual public void Attack() {}
}
