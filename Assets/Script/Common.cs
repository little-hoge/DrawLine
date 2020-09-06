using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ENUM;


// PC画面サイズ設定
public class GameInitial {
#if UNITY_WEBGL


#else
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        Screen.SetResolution(Define.SCREEN_X, Define.SCREEN_Y, false, Define.FPS);

    }
#endif

}

public static class Define {

    // 定数
    public const string GAMETITLE = ("GameTitle");
    public const string GAMESETTING = ("GameSetting");
    public const string GAMEMAIN = ("GameMain");


    // 
    public const int SCREEN_X = (480), SCREEN_Y = (854), FPS = (30);  // 画面設定 
    public const int LIFEMAX = (10);
    public const int REMAINMAX_NORMAL = (50);
    public const int REMAINMAX_HARD = (100);

}

public static class Function {
    /// <summary>
    /// bool型乱数の取得
    /// </summary>
    /// <returns>bool型の乱数</returns>
    public static bool RandomBool() {
        return Random.Range(0, 2) == 0;
    }

}

// 共有データ
public class Data {
    public readonly static Data Instance = new Data();

    // ゲーム状態
    public eGameState gameState = ENUM.eGameState.GAMEMAIN;

    /// <summary> 残り </summary>
    public int remain;

    /// <summary> ライフ </summary>
    public int life;

    /// <summary> 残り目標値 </summary>
    public int remainMAX = Define.REMAINMAX_NORMAL;
}

namespace ENUM {
    public enum eGameState {
        GAMETITLE = 0,
        GAMEMAIN = 1,
        GAMECLEAR = 2,
        GAMEOVER = 3,
    };
}