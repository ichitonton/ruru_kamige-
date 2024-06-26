using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, 0.01f);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.01f);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.01f, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.01f, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0.1f, 0f);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, -0.1f, 0f);
        }
    }
}
