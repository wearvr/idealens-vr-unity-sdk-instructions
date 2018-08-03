using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateIVRCamera : Editor 
{
    [MenuItem("IVRSDK/Creat IVRCamera Component", false, 10)]
    public static void CreateCamera()
    {
        GameObject obj = GameObject.Find("IVRCamera");
        if (obj == null)
        {
            //Creat IVRcamera GameObject
            obj = new GameObject();
            obj.name = "IVRCamera";
            TagHelper.AddTag("IVRCamera");
            obj.tag = "IVRCamera";
            obj.AddComponent<NeedIVRManager>();

            GameObject anchor = new GameObject();
            anchor.name = "Anchor";
            anchor.transform.parent = obj.transform;
            anchor.AddComponent<AudioListener>();
            anchor.AddComponent<Camera>().enabled = false;

            GameObject RightEye = new GameObject();
            RightEye.name = "RightEye";
            RightEye.transform.parent = obj.transform;
            Camera rightCamera = RightEye.AddComponent<Camera>();
            rightCamera.fieldOfView = 90;
#if UNITY_5
            RightEye.AddComponent<FlareLayer>();
#endif
            GameObject LeftEye = new GameObject();
            LeftEye.name = "LeftEye";
            LeftEye.transform.parent = obj.transform;
            Camera leftCamera = LeftEye.AddComponent<Camera>();
            leftCamera.fieldOfView = 90;
#if UNITY_5
            LeftEye.AddComponent<FlareLayer>();
#endif
        }
        else
        {
            RefrashCamer(obj);
        }
        Debug.Log("ivrsdk init completion");
    }
	
    public static void RefrashCamer(GameObject ivrcamera)
    {
        Transform root = ivrcamera.transform;
        Transform anchorTras = root.Find("Anchor");
        Transform RightEyeTras = root.Find("RightEye");
        Transform LeftEyeTras = root.Find("LeftEye");
        if (!ivrcamera.GetComponent<NeedIVRManager>())
        {
            ivrcamera.AddComponent<NeedIVRManager>();
        }
        if (anchorTras == null)
        {
            GameObject anchor = new GameObject();
            anchor.name = "Anchor";
            anchor.transform.parent = ivrcamera.transform;
            anchor.AddComponent<AudioListener>();
            anchor.AddComponent<Camera>().enabled = false;
        }
        else
        {
            DestroyImmediate(anchorTras.GetComponent<IVRCamera>());
            if (anchorTras.GetComponent<Camera>())
            {
                anchorTras.GetComponent<Camera>().enabled = false;
            }
            else
            {
                anchorTras.gameObject.AddComponent<Camera>().enabled = false;
            }
        }
        if (RightEyeTras == null)
        {
            GameObject RightEye = new GameObject();
            RightEye.name = "RightEye";
            RightEye.transform.parent = ivrcamera.transform;
            Camera rightCamera = RightEye.AddComponent<Camera>();
            rightCamera.fieldOfView = 90;
#if UNITY_5
            RightEye.AddComponent<FlareLayer>();
#endif
        }
        if (LeftEyeTras == null)
        {
            GameObject LeftEye = new GameObject();
            LeftEye.name = "LeftEye";
            LeftEye.transform.parent = ivrcamera.transform;
            Camera leftCamera = LeftEye.AddComponent<Camera>();
            leftCamera.fieldOfView = 90;
#if UNITY_5
            LeftEye.AddComponent<FlareLayer>();
#endif
        }
    }
}