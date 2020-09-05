using UnityEngine.UI;
using UnityEngine;
using System;

public class MainUIManager : MonoBehaviour {
    /// <summary> 残り表示用文字列 </summary>
    public Text remainText;

    /// <summary> ライフ表示用文字列 </summary>
    public Text lifeText;

    /// <summary> 時間表示用文字列 </summary>
    public Text timeText;

    /// <summary> ゲーム状態表示用文字列 </summary>
    public Text gameStateText;

    /// <summary> ゲーム開始時間 </summary>
    System.DateTime startTime;

    /// <summary> ゲーム中時間 </summary>
    System.TimeSpan deltaTime;

    // 初期化
    void Start() {

        GaameScoreInit();

    }


    // 更新
    void Update() {
        remainText.text = "Remain " + Data.Instance.remain.ToString();
        lifeText.text = "Life " + Data.Instance.life.ToString();

        timeText.text = string.Format("Time:{0:00}:{1:00}.{2:000}" + "\n", deltaTime.Minutes, deltaTime.Seconds, deltaTime.Milliseconds);

        switch (Data.Instance.gameState) {
            case ENUM.eGameState.GAMEMAIN:
                CalcTime();
                break;
            case ENUM.eGameState.GAMEOVER:
                gameStateText.text = "GameOver";
                break;
            case ENUM.eGameState.GAMECLEAR:
                gameStateText.text = "GameClear";
                break;
            default:
                break;
        }

    }

    /// <summary>
    /// ゲームスコア初期化
    /// </summary>
    public void GaameScoreInit() {

        Data.Instance.life = Define.LIFEMAX;
        Data.Instance.remain = Data.Instance.remainMAX;

        remainText.text = "Remain " + Data.Instance.remain.ToString();
        lifeText.text = "Life " + Data.Instance.life.ToString();
        gameStateText.text = "";

        this.startTime = System.DateTime.Now;

    }

    /// <summary>
    /// 時間計算
    /// </summary>
    void CalcTime() {
        deltaTime = System.DateTime.Now - this.startTime;
    }

    /// <summary>
    /// 時間データ取得
    /// </summary>
    public TimeSpan GetClearTime() {
        return deltaTime;
    }

}