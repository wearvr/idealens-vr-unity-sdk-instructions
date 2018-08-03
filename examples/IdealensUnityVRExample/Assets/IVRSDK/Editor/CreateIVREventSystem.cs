using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CreateIVREventSystem : Editor
{
    [MenuItem("IVRSDK/Creat IVREventSystem", false, 12)]
    static void CreateEventSystem()
    {
        GameObject obj = GameObject.Find("EventSystem");
        if (obj == null)
        {
            obj = new GameObject();
            obj.name = "EventSystem";
            obj.AddComponent<EventSystem>();
            obj.AddComponent<IVRInputModule>();
        }
    }

    [MenuItem("IVRSDK/Use IVR Physics Raycast", false, 20)]
    static void CreateIVRPhysicRay()
    {
        GameObject obj = GameObject.Find("IVRCamera");
        if (obj == null)
        {
            CreateIVRCamera.CreateCamera();
            obj = GameObject.Find("IVRCamera");
        }
        Transform anchorTras = obj.transform.Find("Anchor");
        if (!anchorTras.GetComponent<IVRPhysicsRaycaster>())
        {
            anchorTras.gameObject.AddComponent<IVRPhysicsRaycaster>();
        }
        GameObject e = GameObject.Find("EventSystem");
        if (e == null)
        {
            CreateEventSystem();
            e = GameObject.Find("EventSystem");
        }
        e.GetComponent<IVRInputModule>().rayTransform = anchorTras.transform;
    }

    [MenuItem("IVRSDK/Use IVR Graphic Raycast", false, 30)]
    static void CreateIVRGraphicRay()
    {
        Canvas target = Selection.activeGameObject.GetComponent<Canvas>();
        target.renderMode = RenderMode.WorldSpace;
        GameObject obj = GameObject.Find("IVRCamera");
        if (obj == null)
        {
            CreateIVRCamera.CreateCamera();
            obj = GameObject.Find("IVRCamera");
        }
        Transform anchorTras = obj.transform.Find("Anchor");
        target.worldCamera = anchorTras.GetComponent<Camera>();
        target.gameObject.AddComponent<IVRRaycaster>();
    }

    [MenuItem("IVRSDK/Use IVR Graphic Raycast", true)]
    static bool CanCreateIVRGraphicRay()
    {
        if (Selection.activeGameObject == null) return false;
        Canvas target = Selection.activeGameObject.GetComponent<Canvas>();
        if (target == null) return false;
        return true;
    }
}
