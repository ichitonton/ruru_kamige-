using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(GroundChacker))]
[RequireComponent(typeof(PartsManager))]

public class PlayerManager : MonoBehaviour
{
    GroundChacker groundChacker;
    Jump jump;
    PartsManager partsManager;

    //-------------
    Gra gra;
    //-------------

    private int[] treadPartsNums = { (-1), (-1) };
    private int flag;

    // Start is called before the first frame update
    void Start()
    {
        groundChacker = GetComponent<GroundChacker>();
        jump = GetComponent<Jump>();
        partsManager = GetComponent<PartsManager>();

        //------------
        gra = GetComponent<Gra>();
        //------------

        flag = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButton("R"))
        {
            if (treadPartsNums[0] != (-1)) flag = 1;

            if (Input.GetButtonDown("Y")) treadPartsNums[flag] = 0;
            else if (Input.GetButtonDown("X")) treadPartsNums[flag] = 1;
            //else if (Input.GetButtonDown("A")) treadPartsNums[flag] = 3;
            else if (Input.GetButtonDown("B")) treadPartsNums[flag] = 2;
        }
        else if (Input.GetButtonUp("R"))
        {
            treadPartsNums[0] = (-1);
            treadPartsNums[1] = (-1);
            flag = 0;
        }
        else
        {
            int attackPartsNum = (-1);

            if (Input.GetButtonDown("Y")) attackPartsNum = 0;
            else if (Input.GetButtonDown("X")) attackPartsNum = 1;
            //else if (Input.GetButtonDown("A")) attackPartsNum = 3;
            else if (Input.GetButtonDown("B")) attackPartsNum = 2;

            if (attackPartsNum != (-1)) partsManager.Attack(attackPartsNum);

            /*
            if (Input.GetButtonDown("A"))
            {
                if (groundChacker.GetIsGround())
                {
                    jump.StartJump();
                    print("true");
                }
                else
                {
                    print("false");
                }
            }

            if (Input.GetButtonUp("A")) jump.QuitJump();
            *

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    if (gra.GetIG())
            //    {
            //        jump.StartJump();
            //        print("true");
            //    }
            //    else
            //    {
            //        print("false");
            //    }
            //}

            //if (Input.GetKeyUp(KeyCode.Space)) jump.QuitJump();

            /*
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (groundChacker.GetIsGround())
                {
                    jump.StartJump();
                    print("true");
                }
                else
                {
                    print("false");
                }
            }

            if (Input.GetKeyUp(KeyCode.Space)) jump.QuitJump();
            */
        }


        /*
        if (Input.GetKey(KeyCode.Z))
        {
            if (treadPartsNums[0] != (-1)) flag = 1;
            if (Input.GetKeyDown(KeyCode.I)) treadPartsNums[flag] = 0;
            else if (Input.GetKeyDown(KeyCode.J)) treadPartsNums[flag] = 1;
            else if (Input.GetKeyDown(KeyCode.K)) treadPartsNums[flag] = 3;
            else if (Input.GetKeyDown(KeyCode.L)) treadPartsNums[flag] = 2;
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            treadPartsNums[0] = (-1);
            treadPartsNums[1] = (-1);
            flag = 0;
        }
        else
        {
            int attackPartsNum = (-1);

            if (Input.GetKeyDown(KeyCode.I)) attackPartsNum = 0;
            else if (Input.GetKeyDown(KeyCode.J)) attackPartsNum = 1;
            else if (Input.GetKeyDown(KeyCode.K)) attackPartsNum = 3;
            else if (Input.GetKeyDown(KeyCode.L)) attackPartsNum = 2;

            if (attackPartsNum != (-1)) partsManager.Attack(attackPartsNum);
        }
        */

        if ((treadPartsNums[0] != (-1)) && (treadPartsNums[1] != (-1)))
        {
            partsManager.Tread(treadPartsNums[0], treadPartsNums[1]);
            treadPartsNums[0] = (-1);
            treadPartsNums[1] = (-1);
            flag = 0;
        }
    }
}
