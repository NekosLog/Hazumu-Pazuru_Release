/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using System.Collections;
 
public class DropController : MonoBehaviour
{
    // 移動ベクトル
    private Vector3 _moveVector = default;

    // 重力　下方向への加速度
    private float _gravity = -9f;

    // 移動速度の上限
    private const float TERMINAL_SPEED = 7f;

    private void Update()
    {
        // 移動ベクトルに向かって移動する
        transform.position += _moveVector * Time.deltaTime;

        // 重力分下に加速
        _moveVector += Vector3.up * _gravity * Time.deltaTime;

        // 限界速度を超えていないか
        if (_moveVector.magnitude > TERMINAL_SPEED)
        {
            // 移動ベクトルの大きさを上限にする
            _moveVector = _moveVector.normalized * TERMINAL_SPEED;
        }
    }

    /// <summary>
    /// ドロップの移動方向を反射した方向に変えるメソッド
    /// </summary>
    /// <param name="hitNormal">接触部の法線</param>
    public void Reflect(Vector3 hitNormal)
    {
        // 反射後のベクトルを代入
        _moveVector = Reflection.GetReflectVector(_moveVector, hitNormal);
    }

    /// <summary>
    /// ドロップのめり込みを解消するメソッド
    /// </summary>
    /// <param name="embeddingValue">めり込んでいる距離</param>
    public void UnEmbedding(float embeddingValue)
    {
        // めり込んでいる分戻る
        transform.position += -_moveVector * embeddingValue;
    }
}