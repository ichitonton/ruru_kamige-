using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing_LeftArm : MonoBehaviour
{
    public GameObject wing;
    public Transform leftArm;
    public Transform playerRotate;
    public Vector3 pos;
    public Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = leftArm.position;
        rot = playerRotate.localEulerAngles;

        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(wing, new Vector3(pos.x, pos.y, pos.z + 1f), Quaternion.Euler(rot.x + 90f, rot.y, rot.z));
        }
    }
}
