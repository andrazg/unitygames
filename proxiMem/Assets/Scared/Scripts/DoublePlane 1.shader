Shader "DoubleSided" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	}
		SubShader{
		Pass{
		Material{
		Diffuse[_Color]
	}
		Lighting On
		Cull Off
		SetTexture[_BumpMap]{
		constantColor(.5,.5,.5)
		combine constant lerp(texture) previous
	}
		SetTexture[_MainTex]{
		Combine texture * previous DOUBLE, texture*primary
	}
	}
	}
		FallBack "Diffuse", 1
}