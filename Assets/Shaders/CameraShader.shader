Shader "Hidden/CameraShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Saturate("Saturation", Range(0,1)) = 1
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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
			
			sampler2D _MainTex;
			float _Saturate;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float lum = col.r*.3 + col.g*.59 + col.b*.11;
 				float3 bw = float3( lum, lum, lum );
 				col.rgb = lerp(col.rgb, bw, -_Saturate);
				return col;
			}
			ENDCG
		}
	}
}
