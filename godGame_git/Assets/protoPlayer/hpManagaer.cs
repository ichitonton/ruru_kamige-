using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UI;

public class hpManagaer : MonoBehaviour
{
    public float hp;
    //GameObject refObj;
    void Start()
    {
        //refObj = GameObject.Find("wave");
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackObject"))
        {
            --hp;
        }
    }
}
