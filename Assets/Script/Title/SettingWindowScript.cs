using ENUM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingWindowScript : MonoBehaviour
{
    /// <summary> 難易度ノーマル状態 </summary>
    public Toggle toggleNormal;

    /// <summary> 難易度ハード状態 </summary>
    public Toggle toggleHard;

    void Start()
    {
        if (Data.Instance.remainMAX == Define.REMAINMAX_NORMAL) {
            toggleNormal.isOn =true;
        }
        else {
            toggleHard.isOn = true; ;
        }
    }
    void Update()
    {
        if (toggleNormal.isOn) {
            Data.Instance.remainMAX = Define.REMAINMAX_NORMAL;
        }
        else {
            Data.Instance.remainMAX = Define.REMAINMAX_HARD;
        }
    }

    /// <summary>
    /// 戻る釦クリック時
    /// </summary>
    public void OnClickBuckSetting()
    {
        SceneManager.UnloadSceneAsync(Define.GAMESETTING);
    }


}
