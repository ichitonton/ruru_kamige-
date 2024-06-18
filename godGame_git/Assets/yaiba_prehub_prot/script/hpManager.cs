using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class hpManager : MonoBehaviour
{
    public Slider hpSlider;
    public float maxHp;
    float hp;
    //GameObject refObj;
    void Start()
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float atkPower)
    {
        hpSlider.value -= atkPower;
        Debug.Log(gameObject.name +"‚Í" + atkPower + "‚Ìƒ_ƒ[ƒW‚ðŽó‚¯‚½");
        hp -= atkPower;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("attackWave"))
    //    {
    //        //Destroy(other.gameObject);
    //    }
    //    else if (other.CompareTag("attackSlash"))
    //    {
    //        //Destroy(other.gameObject);
    //    }
    //}
}
