using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCount : MonoBehaviour
{
    //�S�ăv���C�x�[�g�Ȃ̂ŁAManager�̕��ŗv�ݒ�
    //�������̃R���|�[�l���g�������Ƃ������\�������邽��


    //[Header("���ԃJ�E���^�̏����l")]
    /*[SerializeField] */
    private int count = 0;
    //[Header("�J�n���ォ��J�E���g���邩")]
    /*[SerializeField] */
    private bool isCounting = true;
    //[Header("���ԃJ�E���^�̍ő�l")]
    /*[SerializeField] */
    private int countMax = 50;
    //[Header("�ő�l�Ń��[�v���邩")]
    private bool isLooping = true;


    //���[�v���邽��true�ɂȂ�M��
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
