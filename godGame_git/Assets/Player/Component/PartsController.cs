using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(PartsTrede))]

public class PartsController : MonoBehaviour
{

    [SerializeField, Header("モデルの関係で要設定 頭についてるパーツをアタッチ")] private PartsManazar head;
    [SerializeField, Header("モデルの関係で要設定 頭についてるパーツをアタッチ")] private PartsManazar left;
    [SerializeField, Header("モデルの関係で要設定 頭についてるパーツをアタッチ")] private PartsManazar right;
    [SerializeField, Header("モデルの関係で要設定 頭についてるパーツをアタッチ")] private PartsManazar leg;

    PartsManazar[] _Parts = new PartsManazar[4];
    PartsTrede partsTrede;

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 4; ++i)
        //    _Parts[i] = transform.transform.GetChild(i).GetChild(0).gameObject.GetComponent<PartsManazar>();

        _Parts[0] = head;
        _Parts[1] = left;
        _Parts[2] = right;
        _Parts[3] = leg;


        _Parts[0].SetPartsList(PartsList.Head);
        _Parts[1].SetPartsList(PartsList.Hand);
        _Parts[2].SetPartsList(PartsList.Hand);
        _Parts[3].SetPartsList(PartsList.Leg);

        for (int i = 0; i < 4; i++) {
            _Parts[i].SetPosition();
            _Parts[i].SetAngle();
            //_Parts[i].SetMesh();
        }

        partsTrede = GetComponent<PartsTrede>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.T))
        //{
        //    Trade(0,1);
        //}
    }

    public void Attack(int partsNum)
    {
        _Parts[partsNum].Action();
    }

    public void Trade(int a, int b)
    {
        partsTrede.Trade(ref _Parts[a], ref _Parts[b]);
        PartsManazar leave = _Parts[a];
        _Parts[a] = _Parts[b];
        _Parts[b] = leave;
    }
}
