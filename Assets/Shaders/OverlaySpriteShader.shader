Shader "Sprites/OverlayBlendingTest"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BlendTex("Blend Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            sampler2D _MainTex;
			sampler2D _BlendTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

			fixed getBlend(fixed targetchannel, fixed blendchannel)
			{
				return (targetchannel > 0.5) * (1 - (1 - 2 * (targetchannel - 0.5)) * (1 - blendchannel)) + (targetchannel <= 0.5) * ((2 * targetchannel) * blendchannel);
			}


            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);


				fixed4 blendcol = tex2D(_BlendTex, i.uv);

				col.r = getBlend(col.r, blendcol.r);
				col.g = getBlend(col.g, blendcol.g);
				col.b = getBlend(col.b, blendcol.b);


                return col;
            }
            ENDCG
        }
    }
}
