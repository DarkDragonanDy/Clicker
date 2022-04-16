using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Swipes{
    left,
    right,
    up,
    down
}

public class SnapScrolling : MonoBehaviour
{
    [Range(0f, 20f)] public float snapSpeed;

    public Swipes typeOfSwipe;
    public int currentPanelId = 1;

    public Vector2 startTouchPosition;
    public Vector2 Distance;
    public Vector2 currentPosition;
    public Vector2 endTouchPosition;
    public  bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    
    
    private Vector2[] pansPos;
    public GameObject[] panels;
    private RectTransform contentRec;
    public int selectedPanelId;
    public bool isScrolling;
    private Vector2 contentVec;
    public ScrollRect scrollRect;

    // public void Swipe()
    // {
    //     // float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
    //     // if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
    //     //
    //     // if (isScrolling ||scrollVelocity > 400 ) return;
    //
    //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //     {
    //         startTouchPosition = Input.GetTouch(0).position;
    //     }
    //
    //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
    //     {
    //         currentPosition = Input.GetTouch(0).position;
    //         Distance = currentPosition - startTouchPosition;
    //         // Debug.LogError(Distance.x);
    //
    //         if (!stopTouch)
    //         {
    //             if (Distance.x < -swipeRange)
    //             {
    //                 Debug.Log("Left");
    //                 typeOfSwipe = Swipes.left;
    //                 //outputText.text = "Left";
    //                 stopTouch = true;
    //             }
    //             else if (Distance.x > swipeRange)
    //             {
    //                 Debug.Log("Right");
    //                 typeOfSwipe = Swipes.right;
    //                 stopTouch = true;
    //             }
    //             // else if (Distance.y > swipeRange)
    //             // {
    //             //     //outputText.text = "Up";
    //             //     stopTouch = true;
    //             // }
    //             // else if (Distance.y < -swipeRange)
    //             // {
    //             //     //outputText.text = "Down";
    //             //     stopTouch = true;
    //             // }
    //
    //         }
    //
    //     }
    //
    //     if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
    //     {
    //         Debug.Log("End");
    //         if (typeOfSwipe == Swipes.right && currentPanelId != 0)
    //         {
    //             currentPanelId -= 1;
    //         }
    //         else if (typeOfSwipe == Swipes.left && currentPanelId != 2)
    //         {
    //             currentPanelId += 1;
    //         }
    //         stopTouch = false;  
    //
    //         // endTouchPosition = Input.GetTouch(0).position;
    //         //
    //         // Vector2 Distance = endTouchPosition - startTouchPosition;
    //         //
    //         // if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
    //         // {
    //         //     //outputText.text = "Tap";
    //         // }
    //     }
    //     if (!isScrolling)
    //     {
    //         contentVec.x = Mathf.SmoothStep(contentRec.anchoredPosition.x, pansPos[currentPanelId].x,
    //             snapSpeed * Time.fixedDeltaTime);
    //         contentVec.y = contentRec.anchoredPosition.y;
    //         contentRec.anchoredPosition = contentVec;
    //     }
    //
    // }

    private void Start()
    {
        contentRec = GetComponent<RectTransform>();
        pansPos = new Vector2[3];
        for (int i = 0; i < 3; i++)
            pansPos[i] = -panels[i].transform.localPosition;
        
    }
    private void FixedUpdate()
    {
        //Swipe();
        float nearestPos = float.MaxValue;
        for (int i = 0; i < 3; i++)
        {
            float distance = Mathf.Abs(contentRec.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanelId = i;
            }
        }
        
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
        
        if (isScrolling ||scrollVelocity > 400 ) return;
        contentVec.x = Mathf.SmoothStep(contentRec.anchoredPosition.x, pansPos[selectedPanelId].x,
            snapSpeed * Time.fixedDeltaTime);
        contentVec.y = contentRec.anchoredPosition.y;
        contentRec.anchoredPosition = contentVec;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }

}
