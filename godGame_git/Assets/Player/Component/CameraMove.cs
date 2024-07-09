using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // �p�x-�ɂȂ��Ă邩�炻���Ώ�����Ώo������
    [SerializeField] GameObject resetTarget;

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



    private Vector3 cameraPos;          // �J�����̈ʒu
    private Vector3 targetPos;          // �����_�̈ʒu

    private bool reset;

    Rigidbody rb;

    private float resetAngleY;
    private float resetAngleX;

    private int count = 0;

    [SerializeField, Header("�J�������Z�b�g�J�E���g")] int resetCount = 10;

    private float resetRato;

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

        reset = false;

        resetAngleY = 0;

        resetRato = (1.0f / resetCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            // ����������Ɖ�]�}���������
            transform.RotateAround(targetPos, player.transform.up, resetAngleY);
            transform.RotateAround(targetPos, transform.right, resetAngleX);
            ++count;
            if (count == resetCount)
            {
                reset = false;
                count = 0;
            }
        }

        else 
        {
            float inputX = Input.GetAxis("RightStickX");
            float inputY = Input.GetAxis("RightStickY");

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

            if (Input.GetButtonDown("L"))
            {
                SetCameraReset();
            }
        }
    }

    private void FixedUpdate()
    {
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
    }

    private Vector3 ExportTargetPos(GameObject obj)
    {
        Vector3 res;
        res.x = obj.transform.position.x;
        res.y = obj.transform.position.y + 2.0f;//������ɂ���
        res.z = obj.transform.position.z;

        //res += obj.transform.right * 0.7f; //�^���ʂ�������悤�ɁA�����L�����N�^�[�̉E�Ɋ񂹂�
        return res;
    }

    public void SetCameraReset()
    {
        if (reset) return;

        reset = true;

        //�J�����̈ʒu�����߂�i�L�����N�^�̌�������distance�����ړ��������n�_
        Vector3 k = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if(k.sqrMagnitude == 0.0f) k = player.transform.forward;

        k = player.transform.forward; //�L�����N�^�[�̐��ʕ����̃x�N�g�����擾
        k = k * -1; //-1���|���ăL�����N�^�[�̐^�������̃x�N�g���ɂ���
        k = k.normalized * distance;//normalized�ōő�l���}1�ɂ��Ă���A�x�N�g���̒�����distance�ɂ���
        resetTarget.transform.position = targetPos + k; //�J�����̈ʒu�����肷��

        //�J�����𒍎��_�֌�����
        resetTarget.transform.LookAt(targetPos);

        float targetAngle = resetTarget.transform.eulerAngles.y;
        float cameraAngle = transform.eulerAngles.y;

        resetAngleY = targetAngle - cameraAngle;

        resetAngleX = resetTarget.transform.eulerAngles.x - transform.eulerAngles.x;

        print(resetAngleY);

        if(resetAngleY < -180) resetAngleY += 360;
        else if(resetAngleY > 180) resetAngleY -= 360;

        resetAngleY *= resetRato;
        resetAngleX *= resetRato;
    }
}
