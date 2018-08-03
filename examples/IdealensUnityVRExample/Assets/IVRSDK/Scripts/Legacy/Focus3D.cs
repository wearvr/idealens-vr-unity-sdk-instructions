/******************************************************************

** auth : xmh
** date : 2016/5/10 10:20:21
** desc : This program is a thread focus controller.
** Ver. : V1.0.0

******************************************************************/
using UnityEngine;


class Focus3D : MonoBehaviour
{
    /// <summary>
    /// Focus Mode
    /// </summary>
    public enum FocusMode
    {
        Dynamic = 0,
        FixedDepth = 2,
    }
    public float fixedDepth = 5f;
    public float feelDepth = 5f;
    public float scale = 0.3f;
    public Transform m_Target;
    private IVRCamera mCameraFocus;
    private Transform mSelfTransform;
    private Transform mAnchor;
    private Camera m_LeftCamera;
    private Camera m_RightCamera;

    private const float MAX_DSTENCE = 10;
    private Vector3 m_targelocalScale;
    void Awake()
    {
        
        m_targelocalScale = Vector3.one * scale;
        mSelfTransform = transform;
        GameObject ivrcamera = GameObject.FindGameObjectWithTag("IVRCamera");
        if (ivrcamera != null)
        {
            mCameraFocus = ivrcamera.GetComponentInChildren<IVRCamera>();
        }
        
        
    }
    void Start()
    {
        if (m_Target == null)
        {
            m_Target = mSelfTransform;
        }

    }
    //void LateUpdate()
    //{ 
        
    //}
    void Update()
    {
        if (mCameraFocus == null) return;
        if (mAnchor == null || m_LeftCamera == null || m_RightCamera == null)
        {
            mAnchor = IVRManager.Instance.GetEyeAnchor();
            m_LeftCamera = IVRManager.Instance.GetLeftCamera().GetComponent<Camera>();
            m_RightCamera = IVRManager.Instance.GetRightCamera().GetComponent<Camera>();
            if (mAnchor == null || m_LeftCamera == null || m_RightCamera == null) return;
        }

        Vector3 anchorPosition = IVRManager.Instance.GetHeadPosition();
        Quaternion anchorrotation = IVRManager.Instance.GetHeadRotation();
        Vector3 anchorforward = IVRManager.Instance.GetHeadForward();
        Vector3 targetPosition = Vector3.zero;
        if (mCameraFocus.CatAnchor)
        {
            targetPosition = mCameraFocus.HitPoint + (-anchorforward * fixedDepth);
            m_Target.forward = -anchorforward;


            float scaleDivisor = Vector3.Distance(m_Target.position, anchorPosition) / fixedDepth;
            Vector3 targetScale = m_targelocalScale * scaleDivisor;

            m_Target.localScale = targetScale;
        }
        else
        {
            targetPosition = anchorPosition + anchorforward * feelDepth;
            m_Target.forward = -anchorforward;

            float scaleDivisor = Vector3.Distance(m_Target.position, anchorPosition) / fixedDepth;
            Vector3 targetScale = m_targelocalScale * scaleDivisor;

            m_Target.localScale = targetScale;
        }
        //Debug.Log(Time.fixedDeltaTime);
        //float rate = (Time.deltaTime / Time.fixedDeltaTime) * Rate;
        //Vector3 delta = (m_Target.position - targetPosition) * rate;
        //if (delta.magnitude < 0.001f)
        //{
        //    delta = Vector3.zero;
        //}
        //targetPosition += delta;
        //targetPosition = Vector3.Slerp(m_Target.position, targetPosition, Time.deltaTime * 30f);
        m_Target.position = targetPosition;

        Vector2 leftAnchor_screen_pos = m_LeftCamera.WorldToScreenPoint(m_Target.position);
        Vector2 rightAnchor_screen_pos = m_RightCamera.WorldToScreenPoint(m_Target.position);
        Vector2 resolution = IVRManager.Instance.GetRenderTextureResolution();
        Debug.Log("leftAnchor_screen_pos - rightAnchor_screen_pos " + Vector2.Distance(leftAnchor_screen_pos, rightAnchor_screen_pos));
        int offset = (int)((resolution.x / 2) - leftAnchor_screen_pos.x);
        Debug.Log(offset);

        IVRManager.activity.Call("ChangeAnchorPID", offset);
        
    }
}

