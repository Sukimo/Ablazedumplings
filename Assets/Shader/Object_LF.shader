Shader "Unlit/Object_LF"
{
     Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color",Color)=(1,1,1,1)
		_Transperency("Transperency",Range(0.0,1.0))=1
		//[Toggle(GrayScale)]
		//_GrayScale("GrayScale",Float)=0
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

		//ZWrite Off
		//ZTest Off

		Blend SrcAlpha OneMinusSrcAlpha
		AlphaTest Greater 0

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog
			//#pragma shader_feature GrayScale

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _Color;
			float _Transperency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				col=_Color;
				
				//#ifdef GrayScale
				//	col=(col.r+col.g+col.b)/3;
				//#endif
				
				//Transparent
				col.a =_Transperency*col.a;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
	//FallBack Off
}
