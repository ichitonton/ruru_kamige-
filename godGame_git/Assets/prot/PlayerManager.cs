using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Jump))]
[RequireComponent(typeof(GroundChacker))]

public class PlayerManager : MonoBehaviour
{
    GroundChacker groundChacker;
    Jump jump;

    // Start is called before the first frame update
    void Start()
    {
        groundChacker = GetComponent<GroundChacker>();
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (groundChacker.GetIsGround())
            {
                jump.StartJump();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) jump.QuitJump();
        }
}
