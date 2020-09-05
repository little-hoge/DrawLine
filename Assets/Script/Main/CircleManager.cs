using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CircleManager : MonoBehaviour {
    /// <summary> 円オブジェクト </summary>
    public GameObject circleObj;

    /// <summary> 円オブジェクトリスト </summary>
    private List<GameObject> circleObjList;

    /// <summary> 円作成場所オブジェクト </summary>
    public GameObject Box, Box1, Box2, Box3;

    /// <summary> 円作成場所位置リスト </summary>
    private List<Transform> boxList;

    /// <summary> 円作成場所色リスト </summary>
    private List<SpriteRenderer> boxColorList;

    /// <summary> 円作成カウント文字リスト </summary>
    private List<Text> boxTextList;

    // Start is called before the first frame update
    void Start() {
        circleObjList = new List<GameObject>();
        boxList = new List<Transform>();
        boxColorList = new List<SpriteRenderer>();
        boxTextList = new List<Text>();

        boxList.Add(Box.GetComponent<Transform>());
        boxList.Add(Box1.GetComponent<Transform>());
        boxList.Add(Box2.GetComponent<Transform>());
        boxList.Add(Box3.GetComponent<Transform>());

        boxColorList.Add(Box.GetComponent<SpriteRenderer>());
        boxColorList.Add(Box1.GetComponent<SpriteRenderer>());
        boxColorList.Add(Box2.GetComponent<SpriteRenderer>());
        boxColorList.Add(Box3.GetComponent<SpriteRenderer>());

        boxTextList.Add(Box.transform.GetChild(0).gameObject.GetComponent<Text>());
        boxTextList.Add(Box1.transform.GetChild(0).gameObject.GetComponent<Text>());
        boxTextList.Add(Box2.transform.GetChild(0).gameObject.GetComponent<Text>());
        boxTextList.Add(Box3.transform.GetChild(0).gameObject.GetComponent<Text>());

        // 円オブジェクトの作成カウント初期化
        for (int i = 0; i < boxTextList.Count; i++) {
            boxTextList[i].text = Random.Range(1, 5 + 1).ToString();
        }
    }

    /// <summary>
    /// 円オブジェクトの作成カウント初期化
    /// </summary>
    public void BoxCountInit() {

        for (int i = 0; i < boxTextList.Count; i++) {
            boxTextList[i].text = Random.Range(2, 6 + 1).ToString();
        }

    }

    /// <summary>
    /// 円オブジェクトの作成カウント
    /// </summary>
    public void BoxCountDown() {

        for (int i = 0; i < boxTextList.Count; i++) {

            if (1 < int.Parse(boxTextList[i].text)) {
                var num = int.Parse(boxTextList[i].text) - 1;
                boxTextList[i].text = num.ToString();

            }
            else {
                CircleCreate(i);
                boxTextList[i].text = Random.Range(3, 5 + 1).ToString();
            }
        }

    }

    /// <summary>
    /// 円オブジェクトの作成
    /// </summary>
    /// <param name="index"> 添字 </param>
    public void CircleCreate(int index) {

        circleObjList.Add(Instantiate(circleObj, boxList[index].position, Quaternion.identity));
        circleObjList.Last().GetComponent<SpriteRenderer>().color = boxColorList[index].color;

        if (Function.RandomBool()) boxColorList[index].color = Color.red;
        else boxColorList[index].color = Color.blue;

    }

    /// <summary>
    /// 円オブジェクトの全削除
    /// </summary>
    public void AllDeleteCircleObject() {

        for (int i = 0; i < circleObjList.Count; i++) {
            Destroy(circleObjList[i]);
        }
        circleObjList.Clear();

    }

}
