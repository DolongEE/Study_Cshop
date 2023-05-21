using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

//�� ����(Quick Sort)

//��ü�� �߰� ������ ũ�� �� �� ��ȯ
namespace Quick.Sort
{
    public class Study_QuickSort : MonoBehaviour
    {
        //������ ��ȯ
        void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        //������ Ž��
        int Partition(int[] dataSet, int leftIndex, int rightIndex)
        {
            int pivot = dataSet[leftIndex];
            int first = leftIndex + 1;

            //�ϳ��� �÷����� �������� ��
            for (int j = leftIndex + 1; j <= rightIndex; j++)
            {
                if (dataSet[j] < pivot)
                {
                    Swap(dataSet, first, j);
                    first++;
                }
            }            
            
            //���� �� �������� ���� ���� �� ��ȯ
            Swap(dataSet, leftIndex, first - 1);

            return first - 1;
        }

        //�� ����
        public void QuickSort(int[] dataSet, int leftIndex, int rightIndex)
        {
            //���� ���� �ε��� ��
            if (leftIndex < rightIndex)
            {
                int pivotIndex = Partition(dataSet, leftIndex, rightIndex);
                
                //���� ���� ����
                QuickSort(dataSet, leftIndex, pivotIndex - 1);

                //���� ������ ����
                QuickSort(dataSet, pivotIndex + 1, rightIndex);
            }
        }



        void Start()
        {
            int[] dataSet = { 5, 1, 6, 4, 8, 3, 7, 9, 2 };

            //Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");

            QuickSort(dataSet, 0, dataSet.Length - 1);
            Debug.Log("�� ����\n");

            //Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");
        }
    }
}