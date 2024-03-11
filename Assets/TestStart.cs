/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class TestStart : MonoBehaviour 
{
 
	private void Awake()
	{
        TimeManager.StopTime();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TimeManager.StartTime();
            Destroy(this);
        }
    }


}