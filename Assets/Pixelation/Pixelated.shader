﻿Shader "Hidden/Pixelated"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Columns("Pixel Columns", float) = 320
		_rows("Pixel Rows", float) = 320

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
			float _Columns;
			float _rows;
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 uv = i.uv;
				uv.x *= _Columns;
				uv.y *= _rows;

				uv.x = round(uv.x);
				uv.y = round(uv.y);

				uv.x /= _Columns;
				uv.y /= _rows;


				fixed4 col = tex2D(_MainTex, uv);
				// just invert the colors
				//col = 1 - col;
				return col;
			}
			ENDCG
		}
	}
}
