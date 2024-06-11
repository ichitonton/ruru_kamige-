using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraReset : MonoBehaviour
{
    private CameraMove cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = Camera.main.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("L"))   cm.Reset();
    }
}
