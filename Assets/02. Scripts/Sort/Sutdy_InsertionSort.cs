using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//삽입 정렬(insertion Sort)

//데이터 집합을 순회하며 요소를 뽑아 적당한 곳에 다시 삽입
namespace Insertion.Sort
{
    public class Sutdy_InsertionSort : MonoBehaviour
    {
        //삽입 정렬
        public void InsertionSort(int[] dataSet, int length)
        {            
            int temp;
            for (int i = 1; i < length; i++)
            {
                if (dataSet[i - 1] <= dataSet[i])
                    continue;

                for (int j = 0; j < i; j++)
                {
                    //크기 비교 후 삽입
                    if (dataSet[j] > dataSet[i])
                    {
                        temp = dataSet[i];
                        dataSet[i] = dataSet[j];
                        dataSet[j] = temp;
                    }
                }
            }
        }

        
        void Start()
        {
            int[] dataSet = { 6, 4, 2, 3, 1, 5 };


            Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");

            InsertionSort(dataSet, dataSet.Length);
            Debug.Log("삽입 정렬\n");

            Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");
        }

    }
}