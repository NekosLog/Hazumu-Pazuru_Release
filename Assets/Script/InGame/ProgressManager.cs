/* 制作日
*　製作者
*　最終更新日
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class ProgressManager : MonoBehaviour 
{
#if UNITY_EDITOR
	[SerializeField, Tooltip("開始するシーン名")]
	private E_SceneName _sceneName = default;
#endif

    // 現在再生中のシーン
    private Scene _nowScene = default;

    // シングルトン用の自分
    private static ProgressManager _myInstance = default;

    private void Awake()
    {
        // シングルトンの実装
        if (_myInstance == null)
        {
            // 自分を代入して保持する
            _myInstance = this;
        }
        else
        {
            // すでに保持しているからリターン
            Debug.LogError("ProgressManagerが重複した");
            return;
        }


#if UNITY_EDITOR
        // デバッグ用　指定したシーンから始めれるように
        LoadScene(_sceneName);
#else
        // タイトルシーンをロード
        LoadScene(E_SceneName.TitleScene);
#endif
    }

    /// <summary>
    /// 新しいシーンをロードするメソッド
    /// </summary>
    /// <param name="sceneName">ロードしたいシーン</param>
    public void LoadScene(E_SceneName sceneName)
    {
        // 新しいシーンを生成
        SceneManager.LoadScene(sceneName.ToString(), LoadSceneMode.Additive);

        // 前のシーンが存在する場合
        if (_nowScene.name != null)
        {
            // 前のシーンのルートを取得
            GameObject oldSceneRootObject = _nowScene.GetRootGameObjects()[0];

            // 前のルートを非表示　シーンのアンロードに描画しないようにする
            oldSceneRootObject.SetActive(false);

            // 前のシーンをアンロード
            SceneManager.UnloadSceneAsync(_nowScene,UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }
        
        // 新しいシーンを登録
        _nowScene = SceneManager.GetSceneByName(sceneName.ToString());
        print(_nowScene.name);
    }

    /// <summary>
    /// ProgressManagerを取得するためのプロパティ
    /// </summary>
    public static ProgressManager Instance
    {
        // ProgressManagerを返す
        get { return _myInstance; }
    }

    

}