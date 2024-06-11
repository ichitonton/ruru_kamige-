using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Trade))]

public class PartsManager : MonoBehaviour
{
    [Header("ì™")]
    [SerializeField] GameObject Head;
    [Header("ç∂éË")]
    [SerializeField] GameObject LeftHand;
    [Header("âEéË")]
    [SerializeField] GameObject RightHand;
    [Header("ãr")]
    [SerializeField] GameObject Leg;

    GameObject[] limb = new GameObject[4];

    Trade trade;

    // Start is called before the first frame update
    void Start()
    {
        limb[0] = Head;
        limb[1] = LeftHand;
        limb[2] = RightHand;
        limb[3] = Leg;

         trade = GetComponent<Trade>();

        //limb[0].transform.GetChild(0).gameObject.GetComponent<AttackBeem>().Attack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) trade.TradeParts(ref Head, ref RightHand);


        //if(Input.GetKeyDown(KeyCode.W)) transform.forward = new Vector3(0,0,1);
        //if(Input.GetKeyDown(KeyCode.A)) transform.forward = new Vector3(-1,0,0);
        //if(Input.GetKeyDown(KeyCode.S)) transform.forward = new Vector3(0,0,-1);
        //if(Input.GetKeyDown(KeyCode.D)) transform.forward = new Vector3(1,0,0);
    }

    public void Attack(int partsNum)
    {
        limb[partsNum].transform.GetChild(0).gameObject.GetComponent<AttackBase>().Attack();
    }

    public void Tread(int partsNum1, int partsNum2)
    {
        trade.TradeParts(ref limb[partsNum1], ref limb[partsNum2]);
    }
}
