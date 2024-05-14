using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeam_RightHand : MonoBehaviour
{
    public GameObject player; // �v���C���[�I�u�W�F�N�g
    public GameObject halfTorusColliderPrefab; // ���g�[���X�̓����蔻��̃v���n�u
    public KeyCode keyToPress = KeyCode.J; // �������g���K�[����L�[


    private GameObject currentBullet; // �������ꂽ�e�ۂ�ێ����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �L�[�������ꂽ�甼�g�[���X�̓����蔻��𐶐�
        if (Input.GetKeyDown(keyToPress))
        {
            // �v���C���[�̑O���ɓ����蔻��𐶐�
            Vector3 spawnPosition = player.transform.position + player.transform.forward * 2.0f; // �v���C���[�̑O��2���[�g��
            Quaternion spawnRotation = player.transform.rotation;
            GameObject halfTorusCollider = Instantiate(halfTorusColliderPrefab, spawnPosition, spawnRotation);

            // ���g�[���X�̓����蔻��ɃR���C�_�[�����邩�m�F
            Collider collider = halfTorusCollider.GetComponent<Collider>();
            if (collider != null)
            {
                // �R���C�_�[�̏Փ˃C�x���g���Ď�
                //collider.gameObject.GetComponent<Collider>().attachedRigidbody.OnTriggerEnter.AddListener(OnTriggerEnter);
            }

            //void OnTriggerEnter(Collider other)
            //{
            //    // �Փ˂����I�u�W�F�N�g��"enemy"�^�O�����ꍇ�͍폜����
            //    if (other.CompareTag("enemy"))
            //    {
            //        Destroy(other.gameObject);
            //    }
            //}
        }

        // �L�[�������ꂽ��e�ۂ�����
        if (Input.GetKeyUp(KeyCode.J) && halfTorusColliderPrefab != null)
        {
            Destroy(halfTorusColliderPrefab);
        }


    }


    
}

