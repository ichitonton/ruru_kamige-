using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ついてないならつける
[RequireComponent(typeof(Rigidbody))]

public class LateraMovement : MonoBehaviour
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

        float squareMagnitude = new Vector3(rigidbody.velocity.x, 0.0f, rigidbody.velocity.z).sqrMagnitude;

        //最大スピードを超えないようにする
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
        //左右のスピードが0に近づいたら
        if (squareMagnitude <= stopSpeedX)
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }
}
