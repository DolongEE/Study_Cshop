using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class HW1_20230515 : MonoBehaviour
{
    int[] array = new int[9];

    int[] result = new int[81];
    int[] dan_number = new int[81];
    int[] multiple_number = new int[81];

    int count = 0;
    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            array[i] = i + 1;
        }
        //Hw1();
        //Hw2();
        //Hw3();
        Hw4();
    }

    void Hw1()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Debug.Log($"{(i + 1)}x{(j + 1)}={(i + 1) * (j + 1)}\t");
            }                 
        }
    }

    void Hw2()
    {        

        for (int i = 0; i < 9; i+=3)
        {
            for (int j = 0; j < 9; j++)
            {
                Debug.Log($"{(i + 1)}x{(j + 1)}={(j + 1) * (i + 1)}  \t {(i + 2)}x{(j + 1)}={(j + 1) * (i + 2)}\t\t {(i + 3)}x{(j + 1)}={(j + 1) * (i + 3)}\n");
            }            
        }
    }

    void Hw3()
    {
        int ran1, ran2;

        //전체 다 섞일수 있나? i가 너무 적어 다 섞이지 않을 경우가 있음
        //개발 시 큰 틀을 작게 쪼개어 나누어 하나씩 구현 및 조립
        for (int i = 0; i < 9; ++i)
        {
            ran1 = Random.Range(i, 9);
            ran2 = Random.Range(i, 9);

            int temp = array[ran1];
            array[ran1] = array[ran2];
            array[ran2] = temp;
        }

        for (int i = 0; i < 9; i += 3)
        {
            for (int j = 0; j < 9; j++)
            {
                i = array[i];
                Debug.Log($"{array[i]}x{(j + 1)}={array[i] * (j + 1)}    \t {array[i + 1]}x{(j + 1)}={(j + 1) * (array[i + 1])}    \t {(array[i + 2])}x{(j + 1)}={(j + 1) * (array[i + 2])}\n");
            }
        }
    }

    //변수는 명시적으로!!!
    void Hw4()
    {
        int cnt = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                result[cnt] = (i+1) * (j+1);
                dan_number[cnt] = i+1;
                multiple_number[cnt] = j+1;
                cnt++;
            }
        }
        bubble(result);

        for (int i = 0; i < result.Length; i++)
        {
            Debug.Log($"{dan_number[i]}x{multiple_number[i]}={result[i]}\n");
            
        }

    }

    void bubble(int[] arr)
    {
        int temp;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] > arr[j])
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    temp = dan_number[i];
                    dan_number[i] = dan_number[j];
                    dan_number[j] = temp;

                    temp = multiple_number[i];
                    multiple_number[i] = multiple_number[j];
                    multiple_number[j] = temp;
                    count++;
                }
            }
        }
    }

}
