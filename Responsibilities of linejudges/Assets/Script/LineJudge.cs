using TMPro;
using UnityEngine;

public class LineJudge : MonoBehaviour
{
    public GameObject circle;
    public GameObject triangel;
    public GameObject canvas;
    public GameObject text;
    public float rotation;
    public new string name;

    // Start is called before the first frame update
    void Start()
    {
        var gor = gameObject.transform.localEulerAngles;
        gor.z = rotation;
        gameObject.transform.localEulerAngles = gor;


        var cor = canvas.transform.localEulerAngles;
        cor.z = rotation * -1;
        canvas.transform.localEulerAngles = cor;

        text.GetComponent<TMP_Text>().text = name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorChange(Color color)
    {
        circle.GetComponent<Renderer>().material.color = color;
        triangel.GetComponent<Renderer>().material.color = color;
    }

    public void In(GameObject ball, GameObject court)
    {
        // 円の中心座標を取得する
        Vector2 ballCenter = ball.transform.position;
        // 四角の中心座標を取得する
        Vector2 courtCenter = court.transform.position;
        // 四角の幅と高さを取得する
        float courtWidth = court.transform.localScale.x;
        float courtHeight = court.transform.localScale.y;

        float distanceToLeft = Mathf.Abs(ballCenter.x - (courtCenter.x - (courtWidth / 2)));
        float distanceToRight = Mathf.Abs(ballCenter.x - (courtCenter.x + (courtWidth / 2)));
        float distanceToBottom = Mathf.Abs(ballCenter.y - (courtCenter.y - (courtHeight / 2)));
        float distanceToTop = Mathf.Abs(ballCenter.y - (courtCenter.y + (courtHeight / 2)));

        switch (name)
        {
            case "L1":
                if (distanceToTop < 2)
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L2":
                if (distanceToLeft < 2)
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L3":
                if (distanceToBottom < 2)
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L4":
                if (distanceToRight < 2)
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;
            default:
                break;
        }
    }

    public void Out(GameObject ball, GameObject court)
    {
        // 円の中心座標を取得する
        Vector2 ballCenter = ball.transform.position;
        // 四角の中心座標を取得する
        Vector2 courtCenter = court.transform.position;

        // 四角の幅と高さを取得する
        float courtWidth = court.transform.localScale.x;
        float courtHeight = court.transform.localScale.y;

        switch (name)
        {
            case "L1":
                if (ballCenter.y > (courtCenter.y + (courtHeight/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L2":
                if (ballCenter.x < (courtCenter.x - (courtWidth/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L3":
                if (ballCenter.y < (courtCenter.y - (courtHeight/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L4":
                if (ballCenter.x > (courtCenter.x + (courtWidth/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;
            default:
                break;
        }
    }

    public void BallContact(GameObject ball, GameObject court)
    {
        // 円の中心座標を取得する
        Vector2 ballCenter = ball.transform.position;
        // 四角の中心座標を取得する
        Vector2 courtCenter = court.transform.position;

        // 四角の幅と高さを取得する
        float courtWidth = court.transform.localScale.x;
        float courtHeight = court.transform.localScale.y;

        switch (name)
        {
            case "L1":

                if(ballCenter.x < 0)
                {
                    ColorChange(Color.red);
                }
                else if (ballCenter.y > (courtCenter.y + (courtHeight/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L2":
                if (ballCenter.x < 0)
                {
                    ColorChange(Color.red);
                }
                else if (ballCenter.x < (courtCenter.x - (courtWidth/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L3":
                if (ballCenter.x > 0)
                {
                    ColorChange(Color.red);
                }
                else if (ballCenter.y < (courtCenter.y - (courtHeight/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;

            case "L4":
                if (ballCenter.x > 0)
                {
                    ColorChange(Color.red);
                }
                else if (ballCenter.x > (courtCenter.x + (courtWidth/2)))
                {
                    ColorChange(Color.red);
                }
                else
                {
                    ColorChange(Color.white);
                }
                break;
            default:
                break;
        }
    }
}