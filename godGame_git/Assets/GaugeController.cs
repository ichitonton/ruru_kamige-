using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    private Material mat; // Material�̃C���X�^���X
    private Image img; //�A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g��Image�R���|�[�l���g
    [SerializeField, Range(0.0f, 1.0f)] private float fillAmount = 1.0f;//�Q�[�W��

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>(); // Image�R���|�[�l���g�擾
        mat = Instantiate(img.material); // Material�̃C���X�^���X����
        mat.SetColor("_Color", img.color); // Material�̐F�w��
        img.material = mat; // image��Material���C���X�^���X������Material�ɕύX
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_FillAmount", fillAmount);
    }

    //�Q�[���I�u�W�F�N�g���j������ꂽ�Ƃ��ɌĂяo�����
    private void OnDestroy()
    {
        //�C���X�^���X�������Ă�����j������
        if (mat != null)
        {
            Destroy(mat);
        }
    }
}
