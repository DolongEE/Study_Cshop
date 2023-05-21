using UnityEngine;

//���� ����(Bubble Sort)

//�̿� ��ҳ��� ũ�� �� �� ��ȯ
namespace Bubble.Sort
{
    public class Study_BubbleSort : MonoBehaviour
    {
        //���� ����
        public void BubbleSort(int[] dataSet, int length)
        {
            int temp = 0;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    //ũ�� �� �� ��ȯ
                    if (dataSet[j] > dataSet[j + 1])
                    {
                        temp = dataSet[j];
                        dataSet[j] = dataSet[j + 1];
                        dataSet[j + 1] = temp;
                    }
                }
            }
        }        

        void Start()
        {
            int[] dataSet = { 6, 4, 2, 3, 1, 5 };


            Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");

            BubbleSort(dataSet, dataSet.Length);
            Debug.Log("���� ����\n");

            Debug.Log($"DataSet: {{ {dataSet[0]}, {dataSet[1]}, {dataSet[2]}, {dataSet[3]}, {dataSet[4]}, {dataSet[5]} }} \n");
        }
    }
}