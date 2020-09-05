using UnityEngine;

public class GameManager : MonoBehaviour {
    /// <summary> 円管理 </summary>
    public CircleManager circleManager;

    /// <summary> ライン管理 </summary>
    public LineManager lineManager;

    /// <summary> ゴールパネルオブジェクト </summary>
    public MainUIManager mainUIManager;

    /// <summary> 線作成中フラグ </summary>
    private bool clickFlg;

    /// <summary> 前回ゲーム状態フラグ </summary>
    private bool lastgGameStateFlg;


    // Update is called once per frame
    void Update() {

        if (Data.Instance.gameState == ENUM.eGameState.GAMEMAIN) {

            // ボタンが押された時に線オブジェクトの追加を行う
            if (Input.GetMouseButtonDown(0)) {

                // 追加予定位置表示の初期化
                lineManager.GhostLineInit();

                // 開始位置情報の更新
                lineManager.LineStartPositionUpdata();

                clickFlg = true;
            }

            // ボタンが押されている時、線オブジェクトの追加予定位置更新
            if (Input.GetMouseButton(0)) {

                lineManager.GhostLineUpdata();
            }

            // ボタンが押されている時、線オブジェクトの追加予定位置更新
            if (Input.GetMouseButton(0) && Input.GetMouseButtonDown(1) && clickFlg) {

                lineManager.DeleteLineCancelObject();

                clickFlg = false;
            }

            // ボタンを離した時、
            if (Input.GetMouseButtonUp(0) && clickFlg) {

                // 線オブジェクトの追加
                lineManager.AddLineObject();

                // 当たり判定追加
                lineManager.AddEdgeCollider();

                // 終了位置情報の更新
                lineManager.LineEndPositionUpdata();

                // 追加予定位置表示の初期化
                lineManager.GhostLineInit();

                // 円生成カウント
                circleManager.BoxCountDown();

                // 削除
                lineManager.DeleteLineObject();

                clickFlg = false;
            }

        }

        if (Data.Instance.gameState == ENUM.eGameState.GAMECLEAR && !lastgGameStateFlg) {
            if (Data.Instance.remainMAX == Define.REMAINMAX_NORMAL) {
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(mainUIManager.GetClearTime(), 0);
            }
            else {
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(mainUIManager.GetClearTime(), 1);
            }
            lastgGameStateFlg = true;
        }
        else if (Data.Instance.gameState == ENUM.eGameState.GAMEOVER && !lastgGameStateFlg) {

            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(mainUIManager.GetClearTime(), 2);

            lastgGameStateFlg = true;
        }

    }

    /// <summary>
    /// リトライ釦クリック時
    /// </summary>
    public void OnClickRetry() {
        lineManager.AllDeleteLineObject();
        circleManager.AllDeleteCircleObject();
        circleManager.BoxCountInit();
        mainUIManager.GaameScoreInit();
        Data.Instance.gameState = ENUM.eGameState.GAMEMAIN;
        lastgGameStateFlg = false;
    }


    /// <summary>
    /// ゲームタイトル釦クリック時
    /// </summary>
    public void OnClickGameTitle() {

        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(Define.GAMEMAIN);
        Data.Instance.gameState = ENUM.eGameState.GAMETITLE;
    }

}
