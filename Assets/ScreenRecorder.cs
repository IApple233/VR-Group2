using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class ScreenRecorder : MonoBehaviour
{
	public Camera cam;
	private RenderTexture rt;
	private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		
        counter += 1;
		if (counter % 10 == 0) 
		{
			// Save Camera capture
			rt = cam.targetTexture;
			if (rt != null)
			{
				_SaveRenderTexture(rt);
				rt = null;
			} else {
				GameObject camGo = new GameObject("camGo");
				Camera tmpCam = camGo.AddComponent<Camera>();
				tmpCam.CopyFrom(cam);
				rt = RenderTexture.GetTemporary(Screen.width, Screen.height, 16, RenderTextureFormat.ARGB32);
				tmpCam.targetTexture = rt;
				tmpCam.Render();
				_SaveRenderTexture(rt);
				Destroy(camGo);
				RenderTexture.ReleaseTemporary(rt);
				rt = null;
			}
			string path = string.Format("Assets/../rt_{0}_{1}_{2}.txt", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
			string json = string.Format("{0} {1} {2}", cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
			FileInfo file = new FileInfo(path);
			StreamWriter sw = file.CreateText();
			sw.WriteLine(json);
			sw.Close();
		}
    }
	
	private void _SaveRenderTexture(RenderTexture rt)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		Texture2D png = new Texture2D(rt.width, rt.height, TextureFormat.ARGB32, false);
		png.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
		png.Apply();
		RenderTexture.active = active;
		byte[] bytes = png.EncodeToPNG();
		string path = string.Format("Assets/../rt_{0}_{1}_{2}.png", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
		FileStream fs = File.Open(path, FileMode.Create);
		BinaryWriter writer = new BinaryWriter(fs);
		writer.Write(bytes);
		writer.Flush();
		writer.Close();
		fs.Close();
		Destroy(png);
		png = null;
	}
	
}
