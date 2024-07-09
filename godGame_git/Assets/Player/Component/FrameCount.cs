using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCount : MonoBehaviour
{
    //全てプライベートなので、Managerの方で要設定
    //複数このコンポーネントをもつことが多い可能性があるため


    //[Header("時間カウンタの初期値")]
    /*[SerializeField] */
    private int count = 0;
    //[Header("開始直後からカウントするか")]
    /*[SerializeField] */
    private bool isCounting = true;
    //[Header("時間カウンタの最大値")]
    /*[SerializeField] */
    private int countMax = 50;
    //[Header("最大値でループするか")]
    private bool isLooping = true;


    //ループするたびtrueになる信号
    private bool signal = false;

    public bool GetSignal() { return signal; }

    public void StartCount() { isCounting = true; }
    public void StopCount() { isCounting = false; }

    public int GetCount() { return count; }

    public void SetCount(int newCount) { count = newCount; }
    public void SetMaxCount(int newCount) { countMax = newCount; }

    //public void Initialize(int countMax,int firstCount,bool _isCounting,bool _isLooping )
    //{

    //}

    private void Update()
    {
        if (signal)
            signal = false;


        if (isCounting)
        {
            if (count >= countMax)
            {
                signal = true;
                if (isLooping)
                {
                    count = 0;
                }
            }
            count++;
        }
    }
}
