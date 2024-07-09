Shader "Hidden/player_bar"
{
    Properties
    {
        //_MainTex ("Texture", 2D) = "white" {}
        _FillAmount("FillAmount", Range(0.0, 1.0)) = 1.0 //�l�𑝌������邽�߂̃v���p�e�B
        _Color("Color", Color) = (1, 1, 1, 1) //�F��ύX���邽�߂̃v���p�e�B
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 _MainTex_TexelSize; //�e�N�X�`���̃T�C�Y�Ɋւ�����
            float _FillAmount;
            fixed4 _Color;

            //sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed color = _Color; //�������̍��W�̐F��_Color��
                float h = _MainTex_TexelSize.w; //�e�N�X�`���̏c�̃s�N�Z����
                float w = _MainTex_TexelSize.z; //�e�N�X�`���̉��̃s�N�Z����

                //���[���΂߂ɂ��鏈��
                if(i.uv.y > i.uv.x * w / h)
                {
                    color.a = 0.0; // �F�̃A���t�@�l��0(����)�ɂ���
                }
                //�E�[���΂߂ɂ��鏈��
                else if(i.uv.y < i.uv.x * w / h - (w - h) / h * _FillAmount)
                {
                    color.a = 0.0; // �F�̃A���t�@�l��0(����)�ɂ���
                }
                return color;

                //fixed4 col = tex2D(_MainTex, i.uv);
                // just invert the colors
                //col.rgb = 1 - col.rgb;
                //return col;
            }
            ENDCG
        }
    }
}
