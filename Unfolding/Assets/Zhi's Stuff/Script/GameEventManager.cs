using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static bool isTouchObject;
    public static string selectedPage;

    private void Start()
    {
        isTouchObject = false;
        selectedPage = "Page Edge 1";
    }
}
