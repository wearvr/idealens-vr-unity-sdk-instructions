/******************************************************************

** auth : xmh
** date : 2016/5/10 10:07:28
** desc : Init Unity Editor property.
** Ver. : V1.0.0

******************************************************************/

using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

[InitializeOnLoad]
class IVRLoader
{
    static IVRLoader()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
            return;

        if (PlayerSettings.defaultInterfaceOrientation != UIOrientation.LandscapeLeft)
        {
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
        }

        //if (QualitySettings.antiAliasing != 0 && QualitySettings.antiAliasing != 1)
        //{
        //    QualitySettings.antiAliasing = 1;
        //}

        if (QualitySettings.vSyncCount != 0)
        {
            QualitySettings.vSyncCount = 0;
        }
        GameObject IVRCamera = GameObject.Find("IVRCamera");
        if (IVRCamera != null)
        {
            CreateIVRCamera.RefrashCamer(IVRCamera);
        }

        TagHelper.AddTag("IVRCamera");
    }
}
