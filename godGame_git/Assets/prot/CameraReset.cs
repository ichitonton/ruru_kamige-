using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    private GameObject cameraObject;
    private CameraMove cm;

    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cm = cameraObject.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("L"))   cm.Reset();
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    cm.Reset();
        //    print("ÇËÇπÇ¡Ç∆Ç≈Ç´ÇΩÅH");
        //}
    }
}
