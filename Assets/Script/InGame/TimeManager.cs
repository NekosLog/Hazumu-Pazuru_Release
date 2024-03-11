/* 制作日 2024/02/22
*　製作者 ニシガキ
*　最終更新日 2024/02/22
*/

using UnityEngine;
using System.Collections;
 
public static class TimeManager 
{
    public static float _deltaTime = Time.deltaTime;

    public static void StopTime()
    {
        Time.timeScale = 0;
    }

    public static void StartTime()
    {
        Time.timeScale = 1;
    }
}