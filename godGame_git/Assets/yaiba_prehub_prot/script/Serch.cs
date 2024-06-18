using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Serch : MonoBehaviour
{

    public string tagSerchTarget;
    private bool detection;
    public bool triggerStay = true;
    GameObject serchTarget;
    void Start()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (triggerStay)
        {
            //tagと一致するobjectを発見していればtrue
            //objectも保存
            if (other.CompareTag(tagSerchTarget))
            {
                Debug.Log("オブジェクトを検知stay！");
                detection = true;
                serchTarget = other.gameObject;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerStay)
        {
            if (other.CompareTag(tagSerchTarget))
            {
                Debug.Log("オブジェクトを検知enter！");
                detection = true;
                serchTarget = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //tagと一致するobjectを発見していればtrue
        //objectも保存
        if (other.CompareTag(tagSerchTarget))
        {
            detection = false;
        }
    }

    public bool GetDetection()
    {
        return detection;
    }

    public GameObject getSerchTarget()
    {
        return serchTarget;
    }
}
