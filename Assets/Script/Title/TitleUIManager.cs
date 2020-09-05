using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour {
    /// <summary>
    /// ランキング釦クリック時
    /// </summary>
    public void OnClickRanking() {
        var timeScore = new System.TimeSpan(0, 23, 59, 59, 999);

        if (Data.Instance.remainMAX == Define.REMAINMAX_NORMAL) {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 0);
        }
        else {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore, 1);
        }

    }

    /// <summary>
    /// ゲームメイン釦クリック時
    /// </summary>
    public void OnClickGameStart() {

        SceneManager.LoadScene(Define.GAMEMAIN);
        Data.Instance.gameState = ENUM.eGameState.GAMEMAIN;
    }

    /// <summary>
    /// 設定釦クリック時
    /// </summary>
    public void OnClickSetting() {

        SceneManager.LoadScene(Define.GAMESETTING, LoadSceneMode.Additive);
    }
}
