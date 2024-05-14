using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject changeUI;
    private GameObject changeUIInstance;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム画面でPキーを押すとポーズ画面に
        if(Input.GetKeyDown(KeyCode.P) && !flag)
        {
            if(changeUIInstance == null)
            {
                flag = true;

                changeUIInstance = Instantiate(changeUI, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
                Time.timeScale = 0f;
            }
            
        }
        
        //ポーズ画面でエンター押すとゲーム画面に戻る
        if(Input.GetKeyDown(KeyCode.Return) && flag)
        {
            flag = false;

            Destroy(changeUIInstance);
            Time.timeScale = 1f;
        }
    }

    void SwitchArmor()
    {

    }
}
