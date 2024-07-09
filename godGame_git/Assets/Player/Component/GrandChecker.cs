using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandChecker : MonoBehaviour
{
    // ===============================================
    // �v���C���[�ɂ����g��񂩂�private�ł�������
    // ===============================================

    //  CastRay�̔�������������ɂ��炷����
    [SerializeField, Header("CastRay�̔�������������ɂ��炷����")]
    const float epsilon = 0.005f;

    [SerializeField,Header("Collider�ƒn�ʂ̋��������̒l��菬������ΐڒn�Ɣ���")]
    float floatingDistance = 0.02f;

    [SerializeField, Header("�ǂ̃��C���[�̃I�u�W�F�N�g�ɓ���������")]
    LayerMask GroundLayerMask;

    private Collider collider;
    private bool IsGround = false;
    private bool IsRoof = false;

    RaycastHit hit;

    //���ۂɂ͐ڒn���Ă��Ȃ����A�ڒn���Ă���Ƃ������Ƃɂ���u�[��
    private bool IsGroundFake = false;
    [Header("�ڒn���Ă��锻��̎����P�\�t���[��")]
    [SerializeField] int IsGroundFrame = 5;
    int IsGroundCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGround = Physics.SphereCast(
            collider.transform.position + new Vector3(0, epsilon, 0),                   // ���ˈʒu
            collider.transform.lossyScale.x * 0.5f,                                     // �傫���@���_����̒��������� /2 ���Ȃ��Ƃ����Ȃ�
            Vector3.down,                                                               // ����
            out hit,                                                                    // �����������̂̏����i�[����
            (collider.transform.lossyScale.y * 0.5f) + floatingDistance + epsilon,      // ���C�̒���
            GroundLayerMask);                                                           // �����������̂̃��C���[�����Ďw�肵�����C���[�Ɠ���������true


        // ���������V��@�܂��o���ĂȂ�
        IsRoof = Physics.SphereCast(
            collider.transform.position - new Vector3(0, -epsilon, 0),
            collider.transform.lossyScale.x * 0.5f,
            Vector3.up,
            out hit,
            (collider.transform.lossyScale.y * 0.5f) + floatingDistance + epsilon,
            GroundLayerMask);
    }

    private void FixedUpdate()
    {
        //------------------------------------------------
        //�ڒn�P�\�t���[���̃J�E���g
        //------------------------------------------------
        if (!IsGround)//�󒆂ɏo��ƃJ�E���g���i��
        {
            IsGroundCount++;
        }
        else if (IsGroundCount != 0)//�ڒn�����烊�Z�b�g
        {
            IsGroundCount = 0;
        }


        if (IsGroundCount > IsGroundFrame)//�P�\�t���[���𒴂���ƁA�U�̐ڒn�����false
        {
            IsGroundFake = false;
        }
        if ((!IsGroundFake) && (IsGround))
        {
            IsGroundFake = true;
        }

    }

    public bool GetIsGroundFake() { return IsGroundFake; }

    public bool GetIsGround() { return IsGround; }

    public bool GetIsRoof() { return IsRoof; }
}
