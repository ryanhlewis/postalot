using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ScrollRect))]
public class ScrollToSelected : MonoBehaviour
{


    public ScrollRect scrollRect;


    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();

    }

    public void UpdateScrollToSelected()
    {

        //Immediately goes to top. Might need some animation..
        scrollRect.verticalNormalizedPosition = 1;
        Debug.Log("hey");

       
    }
}