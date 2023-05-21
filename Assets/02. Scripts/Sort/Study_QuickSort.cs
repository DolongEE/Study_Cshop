using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

//퀵 정렬(Quick Sort)

//전체를 잘게 나누어 크기 비교 및 교환
namespace Quick.Sort
{
    public class Study_QuickSort : MonoBehaviour
    {
        //데이터 교환
        void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        //분할점 탐색
        int Partition(int[] dataSet, int leftIndex, int rightIndex)
        {
            int pivot = dataSet[leftIndex];
            int first = leftIndex + 1;

            //하나씩 늘려가며 기준점과 비교
            for (int j = leftIndex + 1; j <= rightIndex; j++)
            {
                if (dataSet[j] < pivot)
                {
                    Swap(dataSet, first, j);
                    first++;
                }
            }            
            
            //정렬 후 기준점과 가장 작은 값 교환
            Swap(dataSet, leftIndex, first - 1);

            return first - 1;
        }

        //퀵 정렬
        public void QuickSort(int[] dataSet, int leftIndex, int rightIndex)
        {
            //좌측 우측 인덱스 비교
            if (leftIndex < rightIndex)
            {
                int pivotIndex = Partition(dataSet, leftIndex, rightIndex);
                
                //기준 왼쪽 정렬
                QuickSort(dataSet, leftIndex, pivotIndex - 1);

                //기준 오른쪽 정렬
                QuickSort(dataSet, pivotIndex + 1, rightIndex);
            }
        }



        void Start()
        {
            int[] dataSet = { 5, 1, 6, 4, 8, 3, 7, 9, 2 };

            //Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");

            QuickSort(dataSet, 0, dataSet.Length - 1);
            Debug.Log("퀵 정렬\n");

            //Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");
        }
    }
}