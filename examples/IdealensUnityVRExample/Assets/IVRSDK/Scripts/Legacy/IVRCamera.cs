/******************************************************************

** auth : xmh
** date : 2016/5/5 21:51:15
** desc : This program can emit rays, you can shield the different layers by LayerMask
** Ver. : V1.0.0

******************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Obsolete("This is no use in new sdk, IVRPhysicRaycast will handle raycast things!")]
public class IVRCamera : MonoBehaviour
{

    //public int m_Ray_Direction = 5000;
    //public LayerMask m_EventMask;
    //private List<RaycastHit> hits = new List<RaycastHit>();
    private Vector3 hitPoint = Vector3.one;
    ///// <summary>
    ///// 离摄像头最近的焦点
    ///// </summary>
    public Vector3 HitPoint { get { return hitPoint; } }
    ///// <summary>
    ///// 是否看见了AnchorWidget
    ///// </summary>
    public bool CatAnchor;
    //// Each frame emits rays, all colliding objects will be handled by IVRAnchorHandler
    //void Update()
    //{
    //    Ray ray = new Ray() { origin = transform.position, direction = transform.forward * m_Ray_Direction };
    //    RaycastHit[] hit = Physics.RaycastAll(ray, m_Ray_Direction, m_EventMask);
    //    hits.Clear();
    //    hits.AddRange(hit);
    //    hits.Sort((left, right) =>
    //    {
    //        if (left.distance > right.distance)
    //            return 1;
    //        else if (left.distance == right.distance)
    //            return 0;
    //        else
    //            return -1;
    //    });
    //    CatAnchor = hits.Count > 0;
    //    if (CatAnchor)
    //    {
    //        hitPoint = hits[0].point;
    //    }
    //    //IVRAnchorHandler.Instance.RunAnchor(hits.ToArray());
    //}

    ////Ray displayed in editor
    //public void OnDrawGizmos()
    //{
    //    Debug.DrawRay(transform.position, transform.forward * m_Ray_Direction, Color.red);
    //}

}
