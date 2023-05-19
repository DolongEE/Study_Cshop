using Circular.Doubly.Linked.List;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//���� ���� ����Ʈ(DLL : Doubly Linked List)

//������ ��������� ����Ǿ� �ִ� ����Ʈ ����
namespace Doubly.Linked.List
{
    //����� �����͸� ���� �ϱ� ���� Ŭ����
    public class DLL_Node<T>
    {
        public T nodeData { get; set; }
        public DLL_Node<T> prevNode { get; set; }
        public DLL_Node<T> nextNode { get; set; }
    }

    //������� ��� �����͸� ����ϱ� ���� Ŭ����
    public class DLL_LinkedList<T>
    {
        public int _nodeCurrentCount;

        //����Ʈ ù ��°�� �ִ� ��� ����
        public DLL_Node<T> _firstNode { get; private set; }

        //����Ʈ �������� �ִ� ��� ����
        public DLL_Node<T> _lastNode { get; private set; }

        public DLL_LinkedList()
        {
            this._firstNode = null;
            this._lastNode = null;
        }

        //���ο� ��� ���� �Լ�
        public DLL_Node<T> CreateNewNode(T newData)
        {
            //��� ����
            DLL_Node<T> tempNewNode = new DLL_Node<T>();

            //������ ��� �ʱ�ȭ
            tempNewNode.nodeData = newData;
            tempNewNode.prevNode = null;
            tempNewNode.nextNode = null;

            return tempNewNode;
        }

        //��� ���������� �߰� �Լ�
        public void AppendNode(DLL_Node<T> newNode)
        {
            //ù��° ��尡 ������ ���ο� ��尡 ù��° ���
            if(_firstNode == null)
            {
                _firstNode = newNode;
                _lastNode = newNode;
            }
            else
            {
                //������ ��忡 ���ο� ��� �߰�
                _lastNode.nextNode = newNode;
                newNode.prevNode = _lastNode;
            }

            _nodeCurrentCount++;
        }

        //������� �ڿ� ���ο� ��� ���� �Լ�
        public void InsertAfter(DLL_Node<T> current, DLL_Node<T> newNode)
        {
            newNode.nextNode = current.nextNode;
            newNode.prevNode = current;

            //���� ��� �ڿ� ��尡 �ִٸ� �� ��� ���� ������Ʈ
            if (current.nextNode != null)
            {
                current.nextNode.prevNode = newNode;
            }
            _nodeCurrentCount++;
            current.nextNode = newNode;
        }

        //��� ���� �Լ�
        public void RemoveNode(DLL_Node<T> removeNode)
        {
            //������� ��尡 ù��° ��� �� ���
            if(_firstNode == removeNode)
            {
                //ù��° ��� ���� ������Ʈ(ù��° ��忡 null�� ������ ����)
                _firstNode = removeNode.nextNode;

                //����Ʈ�� ù��° ��尡 ���� ������ ���� ������Ʈ
                if(_firstNode != null)
                {
                    _firstNode.prevNode = null;
                }
            }
            else
            {
                //���� ��� �� �� ��� ���� ������Ʈ�� ���� ���� ��� ���� ����
                DLL_Node<T> temp = removeNode;

                //���� ����� �� ��尡 ������ �� ��� ������Ʈ
                if(removeNode.prevNode != null)
                {
                    removeNode.prevNode.nextNode = temp.nextNode;
                }

                //���� ����� �� ��尡 ������ �� ��� ������Ʈ
                if(removeNode.nextNode != null)
                {
                    removeNode.nextNode.prevNode = temp.prevNode;
                }
            }
            _nodeCurrentCount--;
            removeNode.prevNode = null;
            removeNode.nextNode = null;
        }

        //��� ��ġ Ž�� �Լ�
        public DLL_Node<T> GetNodeAt(int index)
        {
            //��带 ã������ ù��° ��� �Ҵ�
            DLL_Node<T> currentNode = _firstNode;

            //ã������ ��� ��ġ��ŭ �ݺ�
            for (int i = 0; i < index && currentNode != null; i++)
            {
                currentNode = currentNode.nextNode;
            }

            return currentNode;
        }
    }


    public class Study_DoublyLinkedList : MonoBehaviour
    {
        DLL_LinkedList<int> c = new DLL_LinkedList<int>();

        void Start()
        {
            int i = 0;
            int count = 0;
            DLL_Node<int> newNode = null;
            DLL_Node<int> current = null;

            for (i = 0; i < 5; i++)
            {
                newNode = c.CreateNewNode(i);
                c.AppendNode(newNode);
            }

            for (i = 0; i < c._nodeCurrentCount; i++)
            {
                current = c.GetNodeAt(i);
                Debug.Log($"List[{i}] = {current.nodeData}");
            }

            current = c.GetNodeAt(2);
            newNode = c.CreateNewNode(3000);
            c.InsertAfter(current, newNode);

            for (i = 0; i < c._nodeCurrentCount; i++)
            {
                current = c.GetNodeAt(i);
                Debug.Log($"List[{i}] = {current.nodeData}");
            }

            count = c._nodeCurrentCount;

            for (i = 0; i < count; i++)
            {
                current = c.GetNodeAt(0);


                if (current != null)
                {
                    c.RemoveNode(current);
                }
            }

            for (i = 0; i < c._nodeCurrentCount; i++)
            {
                current = c.GetNodeAt(i);
                Debug.Log($"List[{i}] = {current.nodeData}");
            }
        }


    }
}