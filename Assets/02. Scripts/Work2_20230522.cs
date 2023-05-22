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
