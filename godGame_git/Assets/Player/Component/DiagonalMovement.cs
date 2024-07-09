using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ついてないならつける
[RequireComponent(typeof(Rigidbody))]

public class DiagonalMovement : MonoBehaviour
{
    [Header("横移動の最大速度"), SerializeField] float maxSpeed = 5.0f;
    [Header("横移動の加速度"), SerializeField] float AccelX = 60.0f;

    [Header("ブレーキの強さ")]
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

        //最大スピードを超えないようにする
        if (squareMagnitude >= squareMaxSpeed)
            rigidbody.velocity = new Vector3(rigidbody.velocity.x / (squareMagnitude / squareMaxSpeed), rigidbody.velocity.y / (squareMagnitude / squareMaxSpeed), rigidbody.velocity.z / (squareMagnitude / squareMaxSpeed));
    }

    public void Brake()
    {
        float magnitude = rigidbody.velocity.magnitude;
        moveForward = -rigidbody.velocity * BrakePower;

        rigidbody.AddForce(moveForward);

        //スピードが0に近づいたら
        if (rigidbody.velocity.sqrMagnitude <= stopSpeedX)
            rigidbody.velocity = Vector3.zero;
    }
}
