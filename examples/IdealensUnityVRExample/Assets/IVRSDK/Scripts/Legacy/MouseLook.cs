  /* This program is free software. It comes without any warranty, to
     the extent permitted by applicable law. You can redistribute it
     and/or modify it under the terms of the TMG To Public License,
     Version 1, as published by Team Mongo Games. 
     See http://www.teammongogames.kilu.de/Licsence for more details. */

using UnityEngine;
using System.Collections;

[System.Obsolete("This is no use in new sdk!")]
public class MouseLook : MonoBehaviour {

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 0.0f;
    public float sensitivityY = 0.0f;

    public float minimumX = -360f;
    public float maximumX = 360f;

    public float  minimumY = -60f;
    public float maximumY = 60f;

    float rotationX = 0;
    float rotationY = 0;

    Quaternion originalRotation;
	
	bool UseMenu;

	void Start () {

        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        originalRotation = transform.localRotation;
       
#if UNITY_ANDROID && !UNITY_EDITOR
         enabled = false;
#endif
    }
	
	void Update () {
		
        sensitivityX = 3;
        sensitivityY = 3;

        Quaternion yQuaternion;
        Quaternion xQuaternion;

        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

            transform.localRotation = Quaternion.Slerp(transform.localRotation, originalRotation * xQuaternion * yQuaternion,Time.deltaTime * 10f);
        }
        else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);

            xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
       }
       else
       {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);

            yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }

    static float ClampAngle ( float angle, float min, float max)
    {
	    if (angle < -360)
		    angle += 360;
	    if (angle > 360)
		    angle -= 360;
	    return Mathf.Clamp (angle, min, max);
    }

}
