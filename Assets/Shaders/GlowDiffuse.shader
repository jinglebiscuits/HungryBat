Shader "ETLab/GlowDiffuse"
{
	Properties
	{
		_ColorTint("Color Tint", Color) = (1,1,1,1)
		_MainTex("Main Texture", 2D) = "white"{}
		_RimColor("Rim Color", Color) = (1,1,1,1)
		_RimPower("Rim Power", Range(0.5, 8.0)) = 1.059702
		_RimOn("Rim On", Range(0, 1)) = 0.0
	}
	
	SubShader
	{
		Tags{ "RenderType" = "Opaque"}
		
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input
		{
			float4 color : COLOR;
			float2 uv_MainTex;
			float3 viewDir;
		};
		
		float4 _ColorTint;
		sampler2D _MainTex;
		float4 _RimColor;
		float _RimPower;
		float _RimOn;
		
		void surf (Input IN, inout SurfaceOutput o)
		{
			IN.color = _ColorTint;
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * IN.color;
			
			if (_RimOn > 0)
			{
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
			};
		}
		ENDCG
	}
	Fallback "Diffuse"
}