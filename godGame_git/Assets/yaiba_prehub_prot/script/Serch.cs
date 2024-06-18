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
            //tag�ƈ�v����object�𔭌����Ă����true
            //object���ۑ�
            if (other.CompareTag(tagSerchTarget))
            {
                Debug.Log("�I�u�W�F�N�g�����mstay�I");
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
                Debug.Log("�I�u�W�F�N�g�����menter�I");
                detection = true;
                serchTarget = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //tag�ƈ�v����object�𔭌����Ă����true
        //object���ۑ�
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
