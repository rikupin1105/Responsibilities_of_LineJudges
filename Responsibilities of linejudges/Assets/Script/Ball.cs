using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // 円のオブジェクト
    public GameObject ball;
    // 四角のオブジェクト
    public GameObject court;
    // 円の半径
    public float radius;

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;

        // 円と四角が触れているか判定する
        if (IsBallInsideCourt())
        {
            // 触れていたらメッセージを表示する
            text.GetComponent<TMP_Text>().text = "IN";
        }
        else
        {
            text.GetComponent<TMP_Text>().text = "OUT";
        }
    }

    bool IsBallInsideCourt()
    {
        // 円の中心座標を取得する
        Vector2 ballCenter = ball.transform.position;
        // 四角の中心座標を取得する
        Vector2 courtCenter = court.transform.position;
        // 四角の幅と高さを取得する
        float courtWidth = court.transform.localScale.x;
        float courtHeight = court.transform.localScale.y;

        // 四角の各辺に対して最短距離を計算する
        float distanceToLeft = Mathf.Abs(ballCenter.x - (courtCenter.x - courtWidth / 2));
        float distanceToRight = Mathf.Abs(ballCenter.x - (courtCenter.x + courtWidth / 2));
        float distanceToBottom = Mathf.Abs(ballCenter.y - (courtCenter.y - courtHeight / 2));
        float distanceToTop = Mathf.Abs(ballCenter.y - (courtCenter.y + courtHeight / 2));

        // 四角の各隅に対して最短距離を計算する
        float distanceToLeftTopCorner = Mathf.Sqrt(Mathf.Pow(distanceToLeft, 2) + Mathf.Pow(distanceToTop,2));
        float distanceToLeftBottomCorner = Mathf.Sqrt(Mathf.Pow(distanceToLeft, 2) + Mathf.Pow(distanceToBottom, 2));
        float distanceToRightTopCorner = Mathf.Sqrt(Mathf.Pow(distanceToRight, 2) + Mathf.Pow(distanceToTop,2));
        float distanceToRightBottomCorner = Mathf.Sqrt(Mathf.Pow(distanceToRight, 2) + Mathf.Pow(distanceToBottom, 2));


        if(Mathf.Abs(ballCenter.x) < 9 && Mathf.Abs(ballCenter.y) < 5)
        {
            Debug.Log("Ball is touching a court! (1)");
                        return true;
        }
        else if (Mathf.Abs(ballCenter.x) < 9.5 && Mathf.Abs(ballCenter.y) < 4.5)
        {
            Debug.Log("Ball is touching a court! (2)");
            return true;
        }
        //円が
        else if (distanceToLeftTopCorner <= radius || distanceToLeftBottomCorner <= radius || distanceToRightTopCorner <= radius || distanceToRightBottomCorner <= radius)
        {
            Debug.Log("Ball is touching a court! (3)");
            return true;
        }
        else
        {
            Debug.Log("Ball is not inside a court!");
            return false; ;
        }
    }
}
