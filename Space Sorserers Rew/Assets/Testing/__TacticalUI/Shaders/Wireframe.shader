// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "KestrelSoft/Wireframe" 
{
	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Mask("Mask (BW)", 2D) = "white" {}

		_MeshColor("Fill Color", Color) = (0,0,0,1)
		
		_WireColor("Wire Color", Color) = (1,1,1,1)
		_WireframeSize("Wire Size", Range(0,0.5)) = 0.49
		_WireEmission("Wire Emission", Range(0.0, 1.0)) = 0.0
		

	}
    		
	SubShader
	{
		Tags{ "Queue" = "Transparent" "RenderType"="Transparent"}
		Cull off
		ZWrite ON
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
    
		Pass
		{
    		CGPROGRAM
				#pragma target 4.0

				#pragma vertex vert
				#pragma fragment frag
		
				#include "UnityCG.cginc"
				
				uniform float4 _MeshColor;
				uniform float4 _WireColor;
			
				uniform float _WireframeSize;
				uniform float _WireEmission;

				sampler2D _MainTex;
				sampler2D _Mask;
		
				struct Input
				{
					float2 uv_MainTex;
					float2 uv_Mask;
				};

				struct Output
				{
					fixed3 Albedo;
					fixed3 Emission;
					fixed3 Alpha;
				};

				struct vertexInput 
				{
					float4 vertex : POSITION;
					float4 uv : TEXCOORD0;
					float4 color : COLOR;
				};
			
				struct fragmentInput 
				{
					float4 position : SV_POSITION;
					float4 uv : TEXCOORD0;
					float4 color : COLOR;
				
				};
			
				fragmentInput vert(vertexInput vInput) {
					fragmentInput fiOut;
					fiOut.position = UnityObjectToClipPos(vInput.vertex);
			
			
					fiOut.uv = vInput.uv;
					fiOut.color = vInput.color;
			
					return fiOut;
				}
		
				fixed4 frag(fragmentInput fInput) : SV_Target
				{
					
					float4 c;
					float coord = step( _WireframeSize, abs(fInput.uv.x - 0.5)) || step(_WireframeSize, abs(fInput.uv.y - 0.5));
			
					c = lerp(_MeshColor, _WireColor, coord*_WireColor.a);
			
					return c;
				}

				void surf (Input IN, inout Output o)
				{
					// Albedo comes from a texture tinted by color
					fragmentInput fInput;
					fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _MeshColor;
					float coord = step( _WireframeSize, abs(fInput.uv.x - 0.5)) || step(_WireframeSize, abs(fInput.uv.y - 0.5));
					o.Albedo = c.rgb;
					o.Emission = (c.rgb) += coord * _WireEmission;
					o.Alpha = tex2D (_Mask, IN.uv_Mask).a;
				}


    		ENDCG
    	}
    }
}