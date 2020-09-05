using UnityEngine;

public class GoalCollision : MonoBehaviour {

    /// <summary>
    /// オブジェクト接触時
    /// </summary>
    /// <param name="collision"> 接触したオブジェクト </param>
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Circle") {
            if (Data.Instance.gameState == ENUM.eGameState.GAMEMAIN) {
                // 円とゴールの色が同じ時
                if (collision.gameObject.GetComponent<SpriteRenderer>().color
                    == this.gameObject.GetComponent<SpriteRenderer>().color) {

                    Data.Instance.remain--;
                    SoundManager.Instance.PlaySeByName("OK");
                }
                else {
                    Data.Instance.life--;
                    SoundManager.Instance.PlaySeByName("NG");
                }
                if (Data.Instance.life < 1) {
                    Data.Instance.gameState = ENUM.eGameState.GAMEOVER;
                }
                if (Data.Instance.remain < 1) {

                    Data.Instance.gameState = ENUM.eGameState.GAMECLEAR;
                }

            }
            // 円オブジェクト削除
            collision.gameObject.SetActive(false);
        }

    }

}
