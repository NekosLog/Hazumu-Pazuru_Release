/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public static class SelectingBlock 
{
	private static GameObject _selectingBlock = default;
	
	public static void SetBlock(GameObject selectBlock)
    {
        if (_selectingBlock != null)
        {
            _selectingBlock.transform.GetChild(0).GetComponent<Outline>().enabled = false;
        }
        _selectingBlock = selectBlock;
        _selectingBlock.transform.GetChild(0).GetComponent<Outline>().enabled = true;
    }
    
    public static GameObject GetBlock
    {
        get { return _selectingBlock; }
    }
}