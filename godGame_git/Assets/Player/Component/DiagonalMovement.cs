using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ĂȂ��Ȃ����
[RequireComponent(typeof(Rigidbody))]

public class DiagonalMovement : MonoBehaviour
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

        float squareMagnitude = rigidbody.velocity.sqrMagnitude;

        //�ő�X�s�[�h�𒴂��Ȃ��悤�ɂ���
        if (squareMagnitude >= squareMaxSpeed)
            rigidbody.velocity = new Vector3(rigidbody.velocity.x / (squareMagnitude / squareMaxSpeed), rigidbody.velocity.y / (squareMagnitude / squareMaxSpeed), rigidbody.velocity.z / (squareMagnitude / squareMaxSpeed));
    }

    public void Brake()
    {
        float magnitude = rigidbody.velocity.magnitude;
        moveForward = -rigidbody.velocity * BrakePower;

        rigidbody.AddForce(moveForward);

        //�X�s�[�h��0�ɋ߂Â�����
        if (rigidbody.velocity.sqrMagnitude <= stopSpeedX)
            rigidbody.velocity = Vector3.zero;
    }
}
