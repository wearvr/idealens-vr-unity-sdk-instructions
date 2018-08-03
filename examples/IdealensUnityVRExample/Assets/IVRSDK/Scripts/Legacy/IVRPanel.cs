/******************************************************************

** auth : xmh
** date : 2016/5/5 21:51:15
** desc : This class is used to manage focus event, other events are not handled here.
** Ver. : V1.0.0

******************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Obsolete("This is no use in new sdk, all event will be driven by EventSystem!")]
public class IVRPanel : MonoBehaviour
{

    //public IVRPanelLayout m_Layout = IVRPanelLayout.Low;
    //private List<AnchorWidget> mChildWidgetList = new List<AnchorWidget>();
    //private List<AnchorWidget> mFocusChildList = new List<AnchorWidget>();

    //void Update()
    //{
    //    //If no panel is locked, or if the panel is the last one locked, then determine whether the focus was received
    //    if (!IVRAnchorHandler.Instance.isHaveLocker() || IVRAnchorHandler.Instance.CheckTopLocker(this))
    //    {
    //        HoverUpdate();
    //    }
    //}

    ///// <summary>
    ///// Update the focus status of all the children in this panel
    ///// </summary>
    //private void HoverUpdate()
    //{
    //    List<AnchorWidget> allFocusWidgetList = IVRAnchorHandler.Instance.GetCanUseWidgets();
    //    //If this sub-class of panel is in the activated widget list, add it to the focus list, and trigger the focus event
    //    for (int i = 0; i < allFocusWidgetList.Count; i++)
    //    {
    //        if (!mFocusChildList.Contains(allFocusWidgetList[i]) && mChildWidgetList.Contains(allFocusWidgetList[i]))
    //        {
    //            allFocusWidgetList[i].RunOnHover(true);
    //            mFocusChildList.Add(allFocusWidgetList[i]);
    //        }
    //    }

    //    //If the widget in the received focus list lost focus, remove it from the focus list, and trigger the lost focus event
    //    for (int i = 0; i < mFocusChildList.Count; i++)
    //    {
    //        if (!allFocusWidgetList.Contains(mFocusChildList[i]))
    //        {
    //            mFocusChildList[i].RunOnHover(false);
    //            mFocusChildList.Remove(mFocusChildList[i]);
    //        }
    //    }
    //}

    ///// <summary>
    ///// Add Widget, and install Panel to Widget
    ///// </summary>
    ///// <param name="widget">Widget.</param>
    public void AddWidget(AnchorWidget widget)
    {
    //    if (widget != null && !mChildWidgetList.Contains(widget))
    //    {
    //        mChildWidgetList.Add(widget);
    //    }
    }

    ///// <summary>
    ///// Removes the widget.
    ///// </summary>
    ///// <param name="widget">Widget.</param>
    public void RemoveWidget(AnchorWidget widget)
    {
    //    if (widget != null && mChildWidgetList.Contains(widget))
    //    {
    //        mChildWidgetList.Remove(widget);
    //        if (mFocusChildList.Contains(widget))
    //        {
    //            widget.RunOnHover(false);
    //            mFocusChildList.Remove(widget);
    //        }
    //    }
        
    }

    ///// <summary>
    ///// Adds the focus widget.
    ///// </summary>
    ///// <param name="widget">Widget.</param>
    public void AddFocusWidget(AnchorWidget widget)
    {
    //    //Widget is not empty, and is not in the focus list. Moreover, it must be Widget of Panel
    //    if (widget != null && !mFocusChildList.Contains(widget) && mChildWidgetList.Contains(widget))
    //    {
    //        widget.RunOnHover(true);
    //        mFocusChildList.Add(widget);
    //    }
    }

    ///// <summary>
    ///// Removes the focus widget.
    ///// </summary>
    ///// <param name="widget">Widget.</param>
    public void RemoveFocusWidget(AnchorWidget widget)
    {
    //    //Widget is not empty, and it is in the list of focus
    //    if (widget != null && mFocusChildList.Contains(widget))
    //    {
    //        widget.RunOnHover(false);
    //        mFocusChildList.Remove(widget);
    //    }
    }

    ///// <summary>
    ///// Is the focused.
    ///// </summary>
    ///// <returns><c>true</c>, Already received focus, <c>false</c> Have not received focus.</returns>
    ///// <param name="widget">Widget.</param>
    //public bool isFocused(AnchorWidget widget)
    //{
    //    return widget != null && mFocusChildList.Contains(widget);
    //}

    ///// <summary>
    ///// get the number of children that are focus in this panel
    ///// </summary>
    //public int FocusCount()
    //{
    //    return mFocusChildList.Count;
    //}

    ///// <summary>
    ///// Get the child which is focused by index
    ///// </summary>
    //public AnchorWidget GetFocusWidgetByIndex(int index)
    //{
    //    return index < mFocusChildList.Count ? mFocusChildList[index] : null;
    //}

    ///// <summary>
    ///// Is the installed Panel locked?
    ///// </summary>
    ///// <param name="isLock">If set to <c>true</c> is lock.</param>
    public void SetPanelLock(bool isLock)
    {
    //    if (isLock)
    //        IVRAnchorHandler.Instance.AddLocker(this);
    //    else
    //        IVRAnchorHandler.Instance.RemoveLocker(this);
    }

}
