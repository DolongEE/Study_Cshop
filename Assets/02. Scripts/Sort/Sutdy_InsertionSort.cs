using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���� ����(insertion Sort)

//������ ������ ��ȸ�ϸ� ��Ҹ� �̾� ������ ���� �ٽ� ����
namespace Insertion.Sort
{
    public class Sutdy_InsertionSort : MonoBehaviour
    {
        //���� ����
        public void InsertionSort(int[] dataSet, int length)
        {            
            int temp;
            for (int i = 1; i < length; i++)
            {
                if (dataSet[i - 1] <= dataSet[i])
                    continue;

                for (int j = 0; j < i; j++)
                {
                    //ũ�� �� �� ����
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
            Debug.Log("���� ����\n");

            Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");
        }

    }
}