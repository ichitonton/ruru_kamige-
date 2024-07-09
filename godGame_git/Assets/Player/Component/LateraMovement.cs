using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ĂȂ��Ȃ����
[RequireComponent(typeof(Rigidbody))]

public class LateraMovement : MonoBehaviour
{
    [Header("���ړ��̍ő呬�x"), SerializeField] float maxSpeed = 5.0f;
    [Header("���ړ��̉����x"), SerializeField] float AccelX = 60.0f;

    [Header("�u���[�L�̋���")]
    [SerializeField] float BrakePower = 10;

    private Vector2 BrakeVelocity;
    private float stopSpeedX = 0.01f;


    Rigidbody rigidbody;
    private Vector3 moveForward;

    private float squareMaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        squareMaxSpeed = maxSpeed * maxSpeed;
    }

    // Update is called once per frame
    public void Move(Vector3 direction)
    {
        direction.Normalize();
        moveForward = direction * AccelX;

        rigidbody.AddForce(moveForward);

        float squareMagnitude = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z).sqrMagnitude;

        //�ő�X�s�[�h�𒴂��Ȃ��悤�ɂ���
        if (squareMagnitude >= squareMaxSpeed)
            rigidbody.velocity = new Vector3(rigidbody.velocity.x / (squareMagnitude / squareMaxSpeed), rigidbody.velocity.y, rigidbody.velocity.z / (squareMagnitude / squareMaxSpeed));
    }

    public void Brake()
    {
        float magnitude = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z).magnitude;
        BrakeVelocity = new Vector2(rigidbody.velocity.x * BrakePower, rigidbody.velocity.z * BrakePower);
        moveForward = new Vector3(-BrakeVelocity.x, 0, -BrakeVelocity.y);

        rigidbody.AddForce(moveForward);

        float squareMagnitude = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z).sqrMagnitude;
        //���E�̃X�s�[�h��0�ɋ߂Â�����
        if (squareMagnitude <= stopSpeedX)
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }
}
