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

    //내려가는 계단 형식 별
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

    //올라가는 계단 형식 별
    public void UpStairStar()
    {
        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //처음은 공백으로 채움
            for (int j = 0; j < 5 - i; j++)
            {
                result += "  ";
            }

            //남은 나머지 *로 채움
            for (int j = 0; j < i + 1; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //내려가는 계단 뒤집은 형태
    public void InverseDownStairStar()
    {
        
        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //계단이 진행될 수록 별 개수 줄어듬
            for (int j = 0; j < 5 - i; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //올라가는 계단 뒤집은 형태
    public void InverseUpStairStar()
    {
        for (int i = 0; i < 5; i++)
        {
            string result = "";

            //공백으로 채움
            for (int j = 0; j < i; j++)
            {
                result += "  ";
            }

            //남은 나머지 *로 채움
            for (int j = 0; j < 5 - i; j++)
            {
                result += "*";
            }

            Debug.Log($"{result}\n");
        }
    }

    //다이아 몬드 형태 별
    public void DiamondStar()
    {
        //3, 5, 7, 9, 11 ,33 가능
        int starCount = 3;
        int length = starCount / 2;

        for (int index = -length; index < length + 1; index++)
        {
            string result = "";
            int absoluteIndex = index;

            //다이아 몬드 출력이 되도록
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

    //두개의 묶인 다이아몬드 형태 별
    public void TwoDiamondStar()
    {
        //한 줄당 찍을 별 개수
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

    //하트 모양 별 찍기
    public void HeartShapeStarPrint()
    {
        //각 줄마다 별 개수
        int[] starCount = { 2, 6, 10, 8, 6, 4, 2 };

        //하트 출력 for문
        for (int i = 0; i < 7; i++)
        {
            string printResult = "";

            //한줄에 별 위치를 출력 for문
            for (int j = 0; j < 10; j++)
            {
                
                printResult += "*";


            }
            Debug.Log($"{printResult}\n");
        }
    }

    //조건: Debug.Log("*") 한줄만 써서 출력
    /*
    숙제.1

    *
    **
    ***
    ****
    *****

    숙제.2

        *
       **
      ***
     ****
    *****


    숙제.3

    *****
    ****
    ***
    **
    *

    숙제.4

    *****
     ****
      ***
       **
        *

    숙제.5

      *
     ***
    *****
     ***
      *


    숙제.6

       *
      ***
    *******
     *****
    *******
      ***
       *

    숙제.7

      *    *
     ***  ***
    **********
     ********
      ******
       ****
        **

     */

}
