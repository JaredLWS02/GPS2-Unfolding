using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class PageHandler : MonoBehaviour
{
    public GameObject prevPageAnimator;
    public GameObject nextPageAnimator;

    public void EnablePrevPage()
    {
        prevPageAnimator.SetActive(true);
    }

    public void EnableNextPage()
    {
        nextPageAnimator.SetActive(true);
    }

    public void DisablePrevPage()
    {
        prevPageAnimator.SetActive(false);
    }

    public void DisableNextPage()
    {
        nextPageAnimator.SetActive(false);
    }
}
