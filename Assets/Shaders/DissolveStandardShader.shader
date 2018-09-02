// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/DissolveStandardShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_DissolveTex ("Albedo (RGB)", 2D) = "white" {}
		_DissolveAmount("DissolveAmount Amount", Range(0.0, 1)) = 0.5
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard vertex:vert
		//#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _DissolveTex;

		float _DissolveAmount;

		struct Input {
			float2 uv_MainTex;
			float2 uv_DissolveTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)


		void vert(inout appdata_full v) 
		{
			// Do whatever you want with the "vertex" property of v here
			v.vertex.y += smoothstep(0, 1, _DissolveAmount);
			//rememeber it doesn't store vertex position data, every tick it redoes everything
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			fixed4 dissolve = tex2D(_DissolveTex, IN.uv_DissolveTex) * _Color;

			float3 worldNormal = UnityObjectToWorldNormal(o.Normal);
			float3 viewDir = normalize(_WorldSpaceCameraPos);
			
			clip(dissolve - _DissolveAmount * dot(viewDir, worldNormal));

			//o.Albedo = c.rgb * dot(viewDir, worldNormal);
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
