using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̱� ���� ����Ʈ(SLL : Singly Linked List)

//������ �ѹ������θ� ����Ǿ� �ִ� ����Ʈ ����
namespace Singly.Linked.List
{
    //����� �����͸� ���� �ϱ� ���� Ŭ����
    public class SLL_Node<T>
    {
        public T nodeData { get; private set; }
        public SLL_Node<T> nextNode { get; internal set; }

        public SLL_Node(T data)
        {
            this.nodeData = data;
        }
    }

    //������� ��� �����͸� ����ϱ� ���� Ŭ����
    public class SinglyLinkedList<T>
    {
        public int _nodeCurrentCount;
        public SLL_Node<T> _firstNode { get; private set; }

        public SinglyLinkedList()
        {
            this._firstNode = null;
        }

        private SLL_Node<T> CreateNewNode(T newData)
        {
            //���ο� ��带 ��� ��������
            SLL_Node<T> tempNewNode = new SLL_Node<T>(newData);

            //����Ʈ�� ��尡 ���� �� ó�� ��� �Ҵ�
            if (_firstNode == null)
            {
                _firstNode = tempNewNode;
            }

            _nodeCurrentCount++;

            return tempNewNode;
        }

        public SLL_Node<T> FindIndexNode(int index)
        {
            //��尡 �����Ƿ� ���� ����
            if (_firstNode == null)
            {
                Debug.LogError("��尡 �����ϴ�");
                return null;
            }

            //indexNode(ã�� ���ϴ� ���)�� ù��° ��� ���� 
            SLL_Node<T> indexNode = _firstNode;
            //���ϴ� ��带 ã�������� indexNode�� ���� ��� �����Ű�� �ݺ�
            for (int i = 0; i < index; i++)
            {
                indexNode = indexNode.nextNode;
            }

            return indexNode;
        }

        public void AddFirstNode(T newData)
        {
            //���ο� ��带 ��� ��������
            SLL_Node<T> tempNewNode = CreateNewNode(newData);

            //ù�� ° ��带 tempNewNode(���ο� ���)�� ����
            tempNewNode.nextNode = _firstNode;
            _firstNode = tempNewNode;
        }

        public void AddEndNode(T newData)
        {
            //���ο� ��带 ��� ��������
            SLL_Node<T> tempNewNode = CreateNewNode(newData);

            //�� �ڿ� �ִ� ���(Tail)�� ã�� for�� 
            SLL_Node<T> Tail = _firstNode;
            for (int i = 0; i < _nodeCurrentCount && Tail.nextNode != null; i++)
            {
                Tail = Tail.nextNode;
            }

            //���� �ڿ� �ִ� ��带 ����
            Tail.nextNode = tempNewNode;
        }

        public void InsertNodeBefore(int index, T newData)
        {
            //��� �ִ� ���� ������ �����Ƿ� ���� ����
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("��尡 �����ϴ�");
                return;
            }

            //index = 0�� ù ��° ��带 ���ϹǷ� �ش� �Լ� ����
            if (index == 0)
            {
                AddFirstNode(newData);
                return;
            }
            //index�� ��� ���� ���� ��� �ǵڿ� �߰��ϴ� �Լ� ����
            else if (index == _nodeCurrentCount - 1)
            {
                AddEndNode(newData);
                return;
            }

            //���ο� ��带 ��� ��������
            SLL_Node<T> tempNewNode = CreateNewNode(newData);
            //�����͸� �߰��� ��ġ�� ��带 ��� ��������
            SLL_Node<T> indexNode = FindIndexNode(index - 1);

            //index��ġ�� tempNewNode������ ����
            tempNewNode.nextNode = indexNode.nextNode;
            indexNode.nextNode = tempNewNode;

        }

        public void InsertNodeAfter(int index, T newData)
        {
            //���� ����� ��ġ�� ������ ����
            InsertNodeBefore(index + 1, newData);
        }             

        public T GetNodeData(int index)
        {
            //��� �ִ� ���� ������ �����Ƿ� ���� ����
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("��尡 �����ϴ�");
                return default;
            }

            SLL_Node<T> wantNode = FindIndexNode(index);

            return wantNode.nodeData;
        }

        public void RemoveIndexNode(int index)
        {
            //��� �ִ� ���� ������ �����Ƿ� ���� ����
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("��尡 �����ϴ�");
                return;
            }            

            SLL_Node<T> removeNode = FindIndexNode(index);

            if (removeNode == _firstNode)
            {
                _firstNode = removeNode.nextNode;
            }
            else
            {
                //������� ��� �յ� ��� ���� ����
                SLL_Node<T> prevNode = FindIndexNode(index - 1);
                prevNode.nextNode = removeNode.nextNode;
            }
            _nodeCurrentCount--;
        }

        public void RemoveAllNode()
        {
            //��尡 �����Ƿ� ���� ����
            if (_nodeCurrentCount == 0)
            {
                Debug.LogError("��尡 �����ϴ�");
                return;
            }

            //����Ʈ�� �ִ� ��尡 0�� �϶����� ����
            for (int i = _nodeCurrentCount; i == 0; i--)
            {
                RemoveIndexNode(0);
            }
        }
    }

    public class Study_SinglyLinkedList : MonoBehaviour
    {

    }
}