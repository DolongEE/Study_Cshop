using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Work2_20230522 : MonoBehaviour
{

    void Start()
    {
        TwoDiamondStar();
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
        int range = 3;
        for (int i = 0; i < 7; i++)
        {            
            string result = "";
            
            for (int j = 0; j < 7; j++)
            {
                if(j < range || 7 - range <= j )
                {
                    result += "  ";
                }
                else
                {
                    result += "*";                    
                }
            }
            if (i % 2 == 0)
            {
                range -= 3;
            }
            else
            {

            }

            Debug.Log($"{result}\n");
        }
    }

    public void HeartStar()
    {

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
