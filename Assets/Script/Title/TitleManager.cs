/* 制作日 2024/01/13
*　製作者 ニシガキ
*　最終更新日 2024/02/09
*/

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField, Tooltip("メニューの矢印")]
    private Image _titleMenuArrow = default;

    [SerializeField, Tooltip("GameStartの矢印")]
    private RectTransform _gameStartArrowPosition = default;

    [SerializeField, Tooltip("Exitの矢印")]
    private RectTransform _exitArrowPosition = default;


    // タイトルメニュー番号を示す変数
    private int _titleMenuIndex = default;

    // ProgressManager
    private ProgressManager _progressManager = default;

    enum E_MenuIndex
    {
        GameStart = 1,
        Exit = 2
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        // メニュー番号の初期化
        _titleMenuIndex = 1;

        // 矢印の位置の初期化
        ChengeArrowPosition();

        // ProgressManager
        _progressManager = ProgressManager.Instance;
    }

    /// <summary>
    /// Inputの取得と処理
    /// </summary>
    private void Update()
    {
        // 上を押したとき
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // 下限値
            int minIndex = 1;

            // 下限を超えないか判定
            if (_titleMenuIndex > minIndex) 
            {
                // メニュー番号を一つ減らす
                _titleMenuIndex--;
            }
            else
            {
                // 下限を超える場合何もしない
                return;
            }

            // 矢印の見た目を移動
            ChengeArrowPosition();
        }

        // 下を押したとき
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // 上限値
            int maxIndex = Enum.GetValues(typeof(E_MenuIndex)).Length;

            // 上限を超えないか判定
            if (_titleMenuIndex < maxIndex)
            {
                // メニュー番号を一つ増やす
                _titleMenuIndex++;
            }
            else
            {
                // 上限を超える場合何もしない
                return;
            }

            // 矢印の見た目を移動
            ChengeArrowPosition();
        }

        // スペースを押したとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // メニュー番号に応じて処理を実行
            switch (_titleMenuIndex)
            {
                // GameStart
                case (int)E_MenuIndex.GameStart:
                    _progressManager.LoadScene(E_SceneName.InGameScene);
                    break;

                // Exit
                case (int)E_MenuIndex.Exit:
                    Application.Quit();
                    break;
            }
        }
    }

    /// <summary>
    /// 矢印の見た目を移動
    /// </summary>
    private void ChengeArrowPosition()
    {
        switch (_titleMenuIndex)
        {
            case (int)E_MenuIndex.GameStart:
                _titleMenuArrow.rectTransform.position = _gameStartArrowPosition.position;
                break;

            case (int)E_MenuIndex.Exit:
                _titleMenuArrow.rectTransform.position = _exitArrowPosition.position;
                break;
        }
    }
}