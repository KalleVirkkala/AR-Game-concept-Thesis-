using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSystem : MonoBehaviour
{
    Text mytext;
     void Start()
    {
        mytext = GetComponent<Text>();    
    }

    void Update()
    {
        mytext.text = getSystemInfo();


        string json = JsonUtility.ToJson(getSystemInfo());
    }




    public string getSystemInfo()
    {
        string str = "<color=red>SYSTEM INFO</color>";

#if UNITY_IOS
     str += "\n[iphone generation]iPhone.generation.ToString()";
#endif

#if UNITY_ANDROID
        str += "\n[system info]" + SystemInfo.deviceModel;
#endif

        str += "\n[type]" + SystemInfo.deviceType;
        str += "\n[os version]" + SystemInfo.operatingSystem;
        str += "\n[system memory size]" + SystemInfo.systemMemorySize;
        str += "\n[graphic device name]" + SystemInfo.graphicsDeviceName + " (version " + SystemInfo.graphicsDeviceVersion + ")";
        str += "\n[graphic memory size]" + SystemInfo.graphicsMemorySize;
        //str += "\n[graphic pixel fill rate]" + SystemInfo.graphicsPixelFillrate;
        str += "\n[graphic max texSize]" + SystemInfo.maxTextureSize;
        str += "\n[graphic shader level]" + SystemInfo.graphicsShaderLevel;
        str += "\n[support compute shader]" + SystemInfo.supportsComputeShaders;

        str += "\n[processor count]" + SystemInfo.processorCount;
        str += "\n[processor type]" + SystemInfo.processorType;
        str += "\n[support 3d texture]" + SystemInfo.supports3DTextures;
        str += "\n[support shadow]" + SystemInfo.supportsShadows;

        str += "\n[platform] " + Application.platform;
        str += "\n[screen size] " + Screen.width + " x " + Screen.height;
        str += "\n[screen pixel density dpi] " + Screen.dpi;

        return str;
    }

    [System.Serializable]
    public class MyClass
    {
     
        public string Systeminfo;
    }
}