using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Timeline;
using System.Linq;
using System.Runtime.CompilerServices;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects = new GameObject[10];
    public Transform[] transforms = new Transform[10];
    public GameObject serchObj;        //���m����I�u�W�F�N�g
    public float constancyTime = 0.0f;  //�o������Ԋu�̎��ԁA�O�Ȃ�P�x�������s�����
    public bool isPlayTime0 = true;    //�O�b�̎��Ɏ��s���邩
    public int playRepeat = 1;

    int playCount = 0;
    bool timerStart = false;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        Serch serch = serchObj.GetComponent<Serch>();

        if (serch.GetDetection())
        {
            timerStart = true;
        }
        if (timerStart)
        {
            time += Time.deltaTime;
            if (constancyTime > 0.0f || isPlayTime0)
            {
                if (playCount <= 0)
                {
                    spawnObjects();
                    playCount++;
                }
                if (time >= constancyTime && playCount < playRepeat)
                {
                    time = 0.0f;
                    spawnObjects();
                    playCount++;
                }
            }
            else if (constancyTime <= 0.0f && playCount == 0)
            {
                spawnObjects();
                playCount++;
            }
        }


    }
    private void spawnObjects()
    {
        Debug.Log("�o���I");
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject spawnObject = (GameObject)Instantiate(objects[i], transforms[i].position, transforms[i].rotation);
        }
    }
}
