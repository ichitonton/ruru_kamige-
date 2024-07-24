using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(GrandChecker))]
[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(LateraMovement))]
[RequireComponent(typeof(PartsController))]
[RequireComponent(typeof(CameraController))]


[RequireComponent(typeof(hpManager))]
[RequireComponent(typeof(chargeManager))]




public class PlayerManager : MonoBehaviour
{
    //Rigidbody rigidbody;
    GrandChecker grandChecker;
    Jump jump;
    LateraMovement lateraMovement;
    PartsController partsController;
    CameraController cameraController;
    Animator animator;

    private int jumpNum;

    private Vector3 direction;

    private Camera cameraObject;

    private bool nowAttack;
    private int attackCount;

    private float pushZR = 1;
    private float pushZL = 1;

    private bool nowPushZR = false;
    private bool nowPushZL = false;

    private bool triggerZR = false;
    private bool triggerZL = false;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        grandChecker = GetComponent<GrandChecker>();
        jump = GetComponent<Jump>();
        lateraMovement = GetComponent<LateraMovement>();
        partsController = GetComponent<PartsController>();
        cameraController = GetComponent<CameraController>();
        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();

        direction = new Vector3(0,0,0);

        jumpNum = 1;

        cameraObject = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        bool grand = grandChecker.GetIsGround();
        bool grandfake = grandChecker.GetIsGroundFake();
        bool roof = grandChecker.GetIsRoof();

        cameraController.SetCameraMove(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
        if (Input.GetButtonDown("L")) cameraController.SetCameraReset();

        pushZR = Input.GetAxis("ZR");
        pushZL = Input.GetAxis("ZL");

        if (pushZR > 0.9f && !nowPushZR) { triggerZR = true; }
        else if (nowPushZR && pushZR < 0.9f) { nowPushZR = false; }
        if (nowPushZR) { triggerZR = false; }
        if (triggerZR) { nowPushZR = true; }

        if (pushZL > 0.9f && !nowPushZL) { triggerZL = true; }
        else if (nowPushZL && pushZL < 0.9f) { nowPushZL = false; }
        if (nowPushZL) { triggerZL = false; }
        if (triggerZL) { nowPushZL = true; }

        if (nowAttack)
        {
            print("攻撃中");
            ++attackCount;
            if (attackCount == 500)
            {
                attackCount = 0;
                nowAttack = false;
            }
        }
        else
        {
            Vector3 cameraForward = Vector3.Scale(cameraObject.transform.forward, new Vector3(1, 0, 1)).normalized;
            float vertical = Input.GetAxis("LeftStickY");

            //if (Input.GetKey(KeyCode.H)) vertical = 1; else vertical = 0;


            float horizontal = Input.GetAxis("LeftStickX");

            direction = cameraForward * vertical + cameraObject.transform.right * horizontal;

            cameraController.SetResetDirection(direction);

            if (direction != Vector3.zero) animator.Play("run");    // 後で条件変える


            if (Input.GetButtonDown("A"))
            {
                if (grandfake)
                    jump.StartJump();

                else
                {
                    if ((jumpNum > 0))
                    {
                        print("空中ジャンプ");
                        jump.StartJump();
                        --jumpNum;
                    }
                }
            }


            //進む方向に滑らかに向く。
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * 10f);


            if (roof || Input.GetKeyUp(KeyCode.L))
                jump.QuitJump();

            if (roof)
                print("てん");

            if (grand)
                jumpNum = 1;

            if (triggerZL)
            {
                
                animator.Play("kick");
                partsController.Attack(1);
                nowAttack = true;
            }
            if (triggerZR)
            {
                animator.Play("kick");
                partsController.Attack(2);
                nowAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                animator.Play("punch");
                nowAttack = true;
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                animator.Play("kick");
                nowAttack = true;
            }
            if (Input.GetKey(KeyCode.Y))
            {
                animator.Play("run");
                //nowAttack = true;
            }
            if (Input.GetKey(KeyCode.T))
            {
                animator.Play("walk");
                //nowAttack = true;
            }

            if(Input.GetKey(KeyCode.Q))
            {
                animator.Play("Stand");
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                partsController.Trade(0,3);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                partsController.Trade(1,3);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                partsController.Trade(2,3);
            }

        }
        //print(Input.GetAxis("CrossKeyX"));
        //print(Input.GetAxis("CrossKeyY"));

    }

    private void FixedUpdate()
    {
        if (!nowAttack)
        {
            if (direction.sqrMagnitude > 0)
                lateraMovement.Move(direction);
            else lateraMovement.Brake();
        }
    }
}
