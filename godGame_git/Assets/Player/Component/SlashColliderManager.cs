using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashColliderManager : MonoBehaviour
{
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // �����̃A�j���[�V��������ς���̂�Y��Ȃ�
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("kick"))
        {
            Destroy(gameObject);
        }
        */
    }
}
