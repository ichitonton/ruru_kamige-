using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    private Material mat; // Materialのインスタンス
    private Image img; //アタッチされたゲームオブジェクトのImageコンポーネント
    [SerializeField, Range(0.0f, 1.0f)] private float fillAmount = 1.0f;//ゲージ量

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>(); // Imageコンポーネント取得
        mat = Instantiate(img.material); // Materialのインスタンス生成
        mat.SetColor("_Color", img.color); // Materialの色指定
        img.material = mat; // imageのMaterialをインスタンス化したMaterialに変更
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_FillAmount", fillAmount);
    }

    //ゲームオブジェクトが破壊っされたときに呼び出される
    private void OnDestroy()
    {
        //インスタンスを持っていたら破棄する
        if (mat != null)
        {
            Destroy(mat);
        }
    }
}
