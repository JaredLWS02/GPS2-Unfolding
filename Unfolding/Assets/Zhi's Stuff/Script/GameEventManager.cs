using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    // For Objects
    public static bool isTouchObject;

    //For Pages
    public static bool isTouchPage;
    public static string selectedPage;

    private void Start()
    {
        isTouchObject = false;
    }
}
