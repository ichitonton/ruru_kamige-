using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAction_Leg_Attack : MonoBehaviour
{
    public float player_vec = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * player_vec;
        }
    }
}
