using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // �~�̃I�u�W�F�N�g
    public GameObject ball;
    // �l�p�̃I�u�W�F�N�g
    public GameObject court;
    // �~�̔��a
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

        // �~�Ǝl�p���G��Ă��邩���肷��
        if (IsBallInsideCourt())
        {
            // �G��Ă����烁�b�Z�[�W��\������
            text.GetComponent<TMP_Text>().text = "IN";
        }
        else
        {
            text.GetComponent<TMP_Text>().text = "OUT";
        }
    }

    bool IsBallInsideCourt()
    {
        // �~�̒��S���W���擾����
        Vector2 ballCenter = ball.transform.position;
        // �l�p�̒��S���W���擾����
        Vector2 courtCenter = court.transform.position;
        // �l�p�̕��ƍ������擾����
        float courtWidth = court.transform.localScale.x;
        float courtHeight = court.transform.localScale.y;

        // �l�p�̊e�ӂɑ΂��čŒZ�������v�Z����
        float distanceToLeft = Mathf.Abs(ballCenter.x - (courtCenter.x - courtWidth / 2));
        float distanceToRight = Mathf.Abs(ballCenter.x - (courtCenter.x + courtWidth / 2));
        float distanceToBottom = Mathf.Abs(ballCenter.y - (courtCenter.y - courtHeight / 2));
        float distanceToTop = Mathf.Abs(ballCenter.y - (courtCenter.y + courtHeight / 2));

        // �l�p�̊e���ɑ΂��čŒZ�������v�Z����
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
        //�~��
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
