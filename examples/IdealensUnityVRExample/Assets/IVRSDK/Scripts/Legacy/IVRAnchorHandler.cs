/******************************************************************

** auth : xmh
** date : 2016/5/5 21:51:15
** desc : IVRAnchorHandler Class: focused object will be managed, and these objects will execute touchpad event.
** Ver. : V1.0.0

******************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Obsolete("This is no use in new sdk, all event will be driven by EventSystem!")]
public class IVRAnchorHandler {

	private List<AnchorWidget> mFocusWidgetList = new List<AnchorWidget>();
	//private List<IVRPanel> mLockStack = new List<IVRPanel>();
    private static IVRAnchorHandler mInstance;

    public static IVRAnchorHandler Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new IVRAnchorHandler();
            }
            return mInstance;
        }
    }


    public bool isFocused(AnchorWidget widget)
    {
        return false;
        //return mFocusWidgetList.Contains(widget);
    }
    public void AddFocusWidget(AnchorWidget widget)
    {
        //mFocusWidgetList.Add(widget);
    }
    public void RemoveFocusWidget(AnchorWidget widget)
    {
        //if (mFocusWidgetList.Contains(widget)) mFocusWidgetList.Remove(widget);
    }

    /// <summary>
    /// According to current focus target list eliminate lost focus target list
    /// </summary>
    /// <param name="widgets"></param>
    public void CleanNotFocusWidget(List<AnchorWidget> widgets)
    {
    //	for (int i = 0; i < mFocusWidgetList.Count; i++)
    //	{
    //		AnchorWidget item = mFocusWidgetList[i];
    //		if (!widgets.Contains(item))
    //		{
    //               item.LoseFocus();
    //			mFocusWidgetList.Remove(item);
    //		}
    //	}

    //	for (int k = 0; k < widgets.Count; k++) {
    //           for (int i = 0; i < widgets[k].m_panel.FocusCount(); i++)
    //           {
    //               AnchorWidget item = widgets[k].m_panel.GetFocusWidgetByIndex(i);
    //               if (item != null && !widgets.Contains(item))
    //               {
    //                   item.LoseFocus();
    //                   widgets[k].m_panel.RemoveFocusWidget(item);
    //               }
    //           }
    //	}
    }

    /// <summary>
    /// Processing collision point
    /// </summary>
    /// <param name="hits"></param>
    public void RunAnchor(RaycastHit[] mRaycastHit)
    {
    //    lock (mFocusWidgetList)
    //    {
    //        mFocusWidgetList.Clear();
    //        if (mRaycastHit != null)
    //        {
    //            List<AnchorWidget> widgets = new List<AnchorWidget>();
    //            for (int i = 0; i < mRaycastHit.Length; i++)
    //            {
    //                AnchorWidget widegt = mRaycastHit[i].collider.GetComponent<AnchorWidget>();
    //                if (widegt != null)
    //                {
    //                    widegt.SetHiter(mRaycastHit[i].point);
    //                    widgets.Add(widegt);
    //                }
    //                //If the collider is not the trigger, the ray needs to be blocked, after-collision effect won't be resolved
    //                if (!mRaycastHit[i].collider.isTrigger)
    //                {
    //                    break;
    //                }
    //            }
    //            //Find widget in recently locked Panel
    //            if (mLockStack.Count > 0)
    //            {
    //                mFocusWidgetList.AddRange(widgets.FindAll((AnchorWidget widget) =>
    //                {
    //                    return widget.m_panel == mLockStack[mLockStack.Count - 1];
    //                }));
    //            }
    //            else
    //            {
    //                mFocusWidgetList.AddRange(widgets);
    //            }
    //        }
    //    }
    }

    /// <summary>
    /// Is there a locked target?
    /// </summary>
    /// <returns><c>true</c>, there is panel locked, <c>false</c> otherwise.</returns>
    public bool isHaveLocker()
    {
        return false;
    //	return mLockStack.Count > 0;
    }

    ///// <summary>
    //   /// Detect whether the input target is the last locked target
    ///// </summary>
    ///// <returns><c>true</c>, the panel is the last one locked <c>false</c> otherwise.</returns>
    public bool CheckTopLocker(IVRPanel panel)
    {
        return false;
    //       return mLockStack.Count > 0 ? mLockStack[mLockStack.Count - 1] == panel : false;
    }

    //   /// <summary>
    //   /// Add the transmitting panel into the top of locked stack
    //   /// </summary>
    public void AddLocker(IVRPanel panel)
    {
    //       if (panel != null && !mLockStack.Contains(panel))
    //           mLockStack.Add(panel);
    }

    //   /// <summary>
    //   /// If the transmitted panel is in locked stack, remove it from the stack
    //   /// </summary>
    public void RemoveLocker(IVRPanel panel)
    {
    //	if(panel!=null&&mLockStack.Contains(panel))
    //		mLockStack.Remove(panel);
    }

    //   /// <summary>
    //   /// Return all of the received focal AnchorWidget
    //   /// </summary>
    public List<AnchorWidget> GetCanUseWidgets()
    {
    	return mFocusWidgetList;
    }

    //   /// <summary>
    //   /// long press
    //   /// </summary>
    public void Run_onLongPress()
    {
    //       foreach (var item in mFocusWidgetList)
    //       {
    //           item.RunOnLongPress();
    //       }
    }

    //   /// <summary>
    //   /// Swipe
    //   /// </summary>
    //   /// <param name="detal"></param>
    public void Run_onSwipe(SwipEnum type)
    {
    //       foreach (var item in mFocusWidgetList)
    //       {
    //		item.RunOnSwip(type);
    //       }
    }

    ///// <summary>
    //   /// Scroll
    ///// </summary>
    ///// <param name="arg">Argument.</param>
    public void Run_onScroll(Vector2 arg)
    {
    //	foreach (var item in mFocusWidgetList)
    //	{
    //		item.RunOnDrag(arg);
    //	}
    }

    public void Run_onDoubleTap()
    {
    //       foreach (var item in mFocusWidgetList)
    //       {
    //           item.RunOnDoubleClick();
    //       }
    }

    public void Run_onPressDown()
    {
    //       foreach (var item in mFocusWidgetList)
    //       {
    //           item.RunOnPress(true);
    //       }
    }

    public void Run_OnPressUp()
    {
    //       foreach (var item in mFocusWidgetList)
    //       {
    //           item.RunOnPress(false);
    //       }
    }

}
