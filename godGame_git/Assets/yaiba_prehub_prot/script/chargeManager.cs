using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chargeManager : MonoBehaviour
{
    public Slider chargeSlider;
    public float maxCharge;
    float charge;
    //GameObject refObj;
    void Start()
    {
        chargeSlider.maxValue = maxCharge;
        chargeSlider.value = 0;
        charge = maxCharge;
    }

    // Update is called once per frame
    void Update()
    {
        if (charge >= maxCharge)
        {
            //�`���[�W���^���̎��̏���
            //Destroy(gameObject);
        }
    }

    public void TakeCharge(float chgPower)
    {
        chargeSlider.value += chgPower;
        Debug.Log(gameObject.name + "��" + chgPower + "�̃_���[�W���󂯂�");
        charge += chgPower;
    }
}
