using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Work2_20230522 : MonoBehaviour
{

    void Start()
    {
        HeartShapeStarPrint();
    }

    //�������� ��� ���� ��
    public void DownStairStar()
    {
        string result;

        for (int i = 0; i < 5; i++)
        {
            result = "";
            for (int j = 0; j < i + 1; j++)
            {
                result += "*";
            }
            Debug.Log($"{result}\n");
        }
    }

    //�ö󰡴� ��� ���� ��
    public void UpStairStar()
    {
        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //ó���� �������� ä��
            for (int j = 0; j < 5 - i; j++)
            {
                result += "  ";
            }

            //���� ������ *�� ä��
            for (int j = 0; j < i + 1; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //�������� ��� ������ ����
    public void InverseDownStairStar()
    {

        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //����� ����� ���� �� ���� �پ��
            for (int j = 0; j < 5 - i; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //�ö󰡴� ��� ������ ����
    public void InverseUpStairStar()
    {
        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //�������� ä��
            for (int j = 0; j < i; j++)
            {
                result += "  ";
            }

            //���� ������ *�� ä��
            for (int j = 0; j < 5 - i; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //���̾� ��� ���� ��
    public void DiamondStar()
    {
        //3, 5, 7, 9, 11 ,33 ����
        int starCount = 3;
        int length = starCount / 2;

        for (int index = -length; index < length + 1; index++)
        {
            string result = "";
            int absoluteIndex = index;

            //���̾� ��� ����� �ǵ���
            if (index < 0)
            {
                absoluteIndex *= -1;
            }

            for (int j = 0; j < absoluteIndex; j++)
            {
                result += "  ";
            }

            for (int j = 0; j < starCount - absoluteIndex * 2; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //�ΰ��� ���� ���̾Ƹ�� ���� ��
    public void TwoDiamondStar()
    {
        //�� �ٴ� ���� �� ����
        int[] starCount = { 1, 3, 7, 5, 7, 3, 1 };

        for (int i = 0; i < 7; i++)
        {
            string result = "";
            int spaceRange = (7 - starCount[i]) / 2;

            for (int j = 0; j < 7; j++)
            {
                if (j < spaceRange || j >= starCount[i] + spaceRange)
                {
                    result += "  ";
                }
                else
                {
                    result += "*";
                }
            }

            Debug.Log($"{result}\n");
        }
    }

    //��Ʈ ��� �� ���
    public void HeartShapeStarPrint()
    {
        //��Ʈ ��� for��
        for (int i = 0; i < 7; i++)
        {
            string result = "";

            //���ٿ� �� ��ġ�� ��� for��
            for (int j = 0; j < 10; j++)
            {
                if (j < 2 - i && i < 2)
                {
                    result += "  ";
                }
                else if (j < 8 + i  && i < 2)
                {
                    result += "*";
                }
                

                if (j < i - 2 && i >= 2)
                {
                    result += "  ";
                }
                else if(j < 10 - (i - 2) && i >= 2)
                {
                    result += "*";
                }


                
                
                

            }
            Debug.Log($"{result}\n");
        }
    }

    //����: Debug.Log("*") ���ٸ� �Ἥ ���
    /*
    ����.1
    
    *
    **
    ***
    ****
    *****

    ����.2

        *
       **
      ***
     ****
    *****


    ����.3

    *****
    ****
    ***
    **
    *

    ����.4

    *****
     ****
      ***
       **
        *

    ����.5

      *
     ***
    *****
     ***
      *


    ����.6

       *
      ***
    *******
     *****
    *******
      ***
       *

    ����.7

      *    *
     ***  ***
    **********
     ********
      ******
       ****
        **

     */

}
