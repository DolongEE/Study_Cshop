using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ȯ�� ���� ���� ����Ʈ(CDLL : Circular Doubly Linked List)

//������ ����� & �յڰ� ���� �Ǿ� �ִ� ����Ʈ ����
namespace Circular.Doubly.Linked.List
{
    //����� �����͸� ���� �ϱ� ���� Ŭ����
    public class CDLL_Node<T>
    {
        public T nodeData { get; set; }
        public CDLL_Node<T> prevNode { get; set; }
        public CDLL_Node<T> nextNode { get; set; }
    }

    //������� ��� �����͸� ����ϱ� ���� Ŭ����
    public class CircularDoublyLinkedList<T>
    {
        public int _nodeCurrentCount;

        //����Ʈ ù��°�� �ִ� ��� ����
        public CDLL_Node<T> _firstNode { get; private set; }

        //���ο� ��� ���� �Լ�
        public CDLL_Node<T> CreateNewNode(T newData)
        {
            //��� ����
            CDLL_Node<T> newNode = new CDLL_Node<T>();

            newNode.nodeData = newData;
            newNode.prevNode = null;
            newNode.nextNode = null;

            return newNode;
        }

        //����Ʈ�� ��� �߰� �Լ�
        public void AppendNode(CDLL_Node<T> newNode)
        {
            //���ο� ��带 ù��° ��尡 ������ ù��° ��忡 ���� ����
            if (_firstNode == null)
            {
                _firstNode = newNode;

                //ù��° ��尡 �ڱ� �ڽ��� ����Ű���� ���� ������Ʈ(���� ����)
                _firstNode.nextNode = _firstNode;
                _firstNode.prevNode = _firstNode;
            }
            else
            {
                //������ ��带 �ǹ���
                CDLL_Node<T> tail = _firstNode.prevNode;

                tail.nextNode.prevNode = newNode;
                tail.nextNode = newNode;

                newNode.nextNode = _firstNode;
                newNode.prevNode = tail;
            }
            _nodeCurrentCount++;
        }

        //������� �ڿ� ���ο� ��� ���� �Լ�
        public void InsertAfter(CDLL_Node<T> currentNode, CDLL_Node<T> newNode)
        {
            newNode.nextNode = currentNode.nextNode;
            newNode.prevNode = currentNode;

            //���� ����� �� ��� ���� ������Ʈ
            currentNode.nextNode.prevNode = newNode;

            currentNode.nextNode = newNode;

            _nodeCurrentCount++;
        }

        //��� ���� �Լ�
        public void RemoveNode(CDLL_Node<T> removeNode)
        {
            //ù��° ��带 ������
            if (_firstNode == removeNode)
            {
                //������ ��尡 ù��° ����� ���� ��带 ����Ű�� ���� ������Ʈ
                _firstNode.prevNode.nextNode = removeNode.nextNode;

                //ù��° ����� ���� ��尡 ������ ��带 ����Ű�� ���� ������Ʈ
                _firstNode.nextNode.prevNode = removeNode.prevNode;
                                
                _firstNode = removeNode.nextNode;
            }
            else
            {
                //���� ��� �� �� ��� ���� ������Ʈ�� ���� ���� ��� ���� ����
                CDLL_Node<T> temp = removeNode;

                //���� ����� �� ��尡 �� ��带 ����Ű�� ���� ������Ʈ
                removeNode.prevNode.nextNode = temp.nextNode;

                //���� ����� �� ��尡 �� ��带 ����Ű�� ���� ������Ʈ
                removeNode.nextNode.prevNode = temp.prevNode;
            }            
            removeNode.prevNode = null;
            removeNode.nextNode = null;

            _nodeCurrentCount--;
        }

        //��� ��ġ Ž�� �Լ�
        public CDLL_Node<T> GetNodeAt(int index)
        {
            //��带 ã������ ù��° ��� �Ҵ�
            CDLL_Node<T> currentNode = _firstNode;

            //ã������ ��� ��ġ��ŭ �ݺ�
            for (int i = 0; i < index && currentNode != null; i++)
            {
                currentNode = currentNode.nextNode;
            }

            return currentNode;
        }        
    }

    public class Study_CircularLinkedList : MonoBehaviour
    {
        
    }
}