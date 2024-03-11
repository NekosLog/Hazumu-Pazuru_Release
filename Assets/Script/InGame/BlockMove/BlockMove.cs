/* 制作日 2024/02/21
*　製作者 ニシガキ
*　最終更新日 2024/02/21
*/

using UnityEngine;
using System.Collections;
 
/// <summary>
/// ブロックが持つ挙動を実行するクラス
/// </summary>
public class BlockMove : MonoBehaviour 
{
    private bool _isFirst = false;

    /// <summary>
    /// 選択中のブロックの挙動を実行
    /// </summary>
    /// <param name="input">操作入力</param>
    public void ExecutionMove(int input)
    {
        if(SelectingBlock.GetBlock == null)
        {
            return;
        }

        SelectingBlock.GetBlock.GetComponent<IBlockAction>().BlockAction(input);
    }

    private void Update()
    {
        int nowInput = (int)Input.GetAxisRaw("Horizontal");

        if (nowInput == 0)
        {
            _isFirst = true;
        }
        else if (_isFirst)
        {
            ExecutionMove(nowInput);
            _isFirst = false;
        }
    }
}