using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void ShowAdv();

    [DllImport("__Internal")]
    public static extern void SetToLeaderboard(int value);

    [DllImport("__Internal")]
    public static extern string GetLang();
}

