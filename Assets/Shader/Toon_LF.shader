﻿Shader "Toon/Toon_LF"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color",Color)=(1,1,1,1)
		_Transperency("Transperency",Range(0.0,1.0))=1
		[HDR]
		_AmbientColor("Ambient Color",Color) =(0.4,0.4,0.4,1)
		[HDR]
		_SpecularColor("Specular Color",Color)=(0.9,0.9,0.9,1)
		_Glossiness("Glossiness", Float)=32
		[HDR]
		_RimColor("Rim Color",Color)=(1,1,1,1)
		_RimAmount("Rim Amount",Range(0.0,1.0))=0.716
		_RimThreshold("Rim threshold", Range(0.0,1.0))=0.1
    }
    SubShader
    {
        Tags { "LightMode"="ForwardBase" "PassFlags"="OnlyDirectional" }
		Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma multi_compile_fwdbase
          
            #include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				float3 worldNormal :NORMAL;
				float3 viewDir : TEXCOORD1;
				SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
						
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldNormal =UnityObjectToWorldNormal(v.normal);
				o.viewDir = WorldSpaceViewDir(v.vertex);
				TRANSFER_SHADOW(o)
                return o;
            }

			float4 _Color;
			float4 _Transperency;
			float4 _AmbientColor;
			float _Glossiness;
			float4 _SpecularColor;
			float4 _RimColor;
			float _RimAmount;
			float _RimThreshold;


            float4 frag (v2f i) : SV_Target
            {
               float3 normal =normalize(i.worldNormal);
				float NdotL = dot(_WorldSpaceLightPos0, normal);
				float shadow =SHADOW_ATTENUATION(i);
				float lightIntensity = smoothstep(0,0.01,NdotL*shadow);
				float4 light =lightIntensity*_LightColor0;
				
				float3 viewDir =normalize(i.viewDir);
				float3 halfVector = normalize(_WorldSpaceLightPos0+viewDir);
				float NdotH =dot(normal,halfVector);

				float SpecularIntensity =pow(NdotH*lightIntensity,_Glossiness*_Glossiness);
				float SpecularIntensitySmooth =smoothstep(0.005,0.01,SpecularIntensity);
				float4 specular =SpecularIntensitySmooth*_SpecularColor;
				float4 rimDot =1- dot(viewDir,normal);
				float rimIntensity =rimDot*pow(NdotL,_RimThreshold);
				rimIntensity = smoothstep(_RimAmount-0.01,_RimAmount+0.01,rimIntensity);
				float4 rim = rimIntensity*_RimColor;

                float4 sample = tex2D(_MainTex, i.uv);
				_Color.a = _Transperency*_Color.a;
				
                return _Color*sample*(_AmbientColor + light+ specular + rim);
            }
            ENDCG
        }

		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}
