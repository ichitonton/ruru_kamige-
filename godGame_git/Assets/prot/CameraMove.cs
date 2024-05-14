using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class CameraMove : MonoBehaviour
{
    [Header("�v���C���[��ݒ� hierarchy����h���b�O&�h���b�v")]
    public GameObject player;
    [Header("�L�����N�^�[�ƃJ�����̋���")]
    public float distance = 3.0f;              // �J�����̋���
    [Header("�J�������x ��")]
    public float sensitivityX = 300.0f;         // �J�������x
    [Header("�J�������x �c")]
    public float sensitivityY = 300.0f;         // �J�������x
    [Header("�㉺���]")]
    public bool reverseYFg = false;            //�㉺�����̑���𔽓]����ꍇ�A�G�f�B�^�Ń`�F�b�N������
    [Header("���E���]")]
    public bool reverseXFg = false;            //���E�����̑���𔽓]����ꍇ�A�G�f�B�^�Ń`�F�b�N������

    private Vector3 targetPos;          // �����_�̈ʒu

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����̒����_�����߂�i�L�����N�^�[�̏�����j
        targetPos = ExportTargetPos(player); //�L�����N�^�[�̍��W���擾

        //�J�����̈ʒu�����߂�i�L�����N�^�̌�������distance�����ړ��������n�_�j
        Vector3 k = player.transform.forward; //�L�����N�^�[�̐��ʕ����̃x�N�g�����擾
        k = k * -1; //-1���|���ăL�����N�^�[�̐^�������̃x�N�g���ɂ���
        k = k.normalized * distance;//normalized�ōő�l���}1�ɂ��Ă���A�x�N�g���̒�����distance�ɂ���
        this.transform.position = targetPos + k; //�J�����̈ʒu�����肷��

        //�J�����𒍎��_�֌�����
        this.transform.LookAt(targetPos);

        rb = player.GetComponent<Rigidbody>();

        print(transform.eulerAngles.x);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("RightStickX");
        float inputY = Input.GetAxis("RightStickY");

        //�L�����N�^�[���ړ����Ă�����
        Vector3 tpos = ExportTargetPos(player);
        if (tpos != targetPos)
        {
            //�ړ������擾
            Vector3 sa = targetPos - tpos;

            //�J�����̈ʒu����������������
            this.transform.position -= sa;

            //�J�����̒����_���X�V
            targetPos = tpos;
        }

        if (reverseXFg) inputX *= -1; //����rebirthFg�������Ă���Δ��]������
        if (reverseYFg) inputY *= -1; //����rebirthFg�������Ă���Δ��]������

        if (transform.eulerAngles.x - 180.0f > 0)
        {
            if (inputY < 0f)
                inputY = 0;
        }
        else if (transform.eulerAngles.x > 71)
            if (inputY > 0f)
                inputY = 0;

        transform.RotateAround(targetPos, player.transform.up, inputX * sensitivityX * Time.deltaTime);
        transform.RotateAround(targetPos, transform.right, inputY * sensitivityY * Time.deltaTime);
    }

    private Vector3 ExportTargetPos(GameObject obj)
    {
        Vector3 res;
        res.x = obj.transform.position.x;
        res.y = obj.transform.position.y + 1.0f;//������ɂ���
        res.z = obj.transform.position.z;

        //res += obj.transform.right * 0.7f; //�^���ʂ�������悤�ɁA�����L�����N�^�[�̉E�Ɋ񂹂�
        return res;
    }

    public void Reset()
    {
        //�J�����̒����_�����߂�i�L�����N�^�[�̏�����j
        targetPos = ExportTargetPos(player); //�L�����N�^�[�̍��W���擾

        //�J�����̈ʒu�����߂�i�L�����N�^�̌�������distance�����ړ��������n�_�j
        Vector3 k = new Vector3(rb.velocity.x, 0, rb.velocity.z); //�L�����N�^�[�̐��ʕ����̃x�N�g�����擾

        if ((k.x == Vector3.zero.x) && (k.z == Vector3.zero.z))
        {

            k = player.transform.forward; //�L�����N�^�[�̐��ʕ����̃x�N�g�����擾
            k = k * -1; //-1���|���ăL�����N�^�[�̐^�������̃x�N�g���ɂ���
            k = k.normalized * distance;//normalized�ōő�l���}1�ɂ��Ă���A�x�N�g���̒�����distance�ɂ���
            this.transform.position = targetPos + k; //�J�����̈ʒu�����肷��

            //�J�����𒍎��_�֌�����
            this.transform.LookAt(targetPos);

            print("���͖���");
        }
        else
        {
            k = k * -1; //-1���|���ăL�����N�^�[�̐^�������̃x�N�g���ɂ���
            k = k.normalized * distance;//normalized�ōő�l���}1�ɂ��Ă���A�x�N�g���̒�����distance�ɂ���
            this.transform.position = targetPos + k; //�J�����̈ʒu�����肷��

            //�J�����𒍎��_�֌�����
            this.transform.LookAt(targetPos);

            print("���͂���");
        }
    }
}
