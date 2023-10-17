using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class GlobalVariables
{
    public static int chick = 3;

    public static bool win = false;

    public static bool tutorialEnd = false;

    public static bool tutorialFailed = false;

    public static bool addScore = false;

    public static int scores = 0;

    public static string userID = Guid.NewGuid().ToString();

    public static string startTime = DateTime.Now.ToString();

    public static string curLevel = "level 1";
}
