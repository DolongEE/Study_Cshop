using Array.Stack;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//���� ����Ʈ ���� (LLS : Linked List Stack)

//���� ����Ʈ�� ������ ���� 
namespace Linked.List.Stack
{
    //����Ʈ�� ��� ������ Ŭ����
    public class Node<T>
    {
        public T nodeData { get; set; }

        public Node<T> nextNode { get; set; }

        public Node(T data)
        {
            nodeData = data;
            nextNode = null;
        }
    }

    //������� ��� �����͸� ����ϱ� ���� Ŭ����
    public class LinkedListStack<T>
    {
        public int _nodeCurrentCount;

        public Node<T> _firstNode { get; set; }
        public Node<T> _currentTopNode { get; set; }

        public LinkedListStack()
        {
            _firstNode = null; 
            _currentTopNode = null;
        }

        //��� ����
        public Node<T> CreateNewNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //�����͸� ������� �߰�
        public void PushData(Node<T> newNode)
        {
            //������ ��������� ���ο� ���� ù��° ���
            if (_firstNode == null)
            {
                _firstNode = newNode;
            }
            else
            {
                //ž ��� ��ġ Ž��
                Node<T> currentTop = _firstNode;
                                
                for (int i = 0; i < _nodeCurrentCount - 1; i++)
                {
                    currentTop = currentTop.nextNode;
                }

                currentTop.nextNode = newNode;
            }
            _nodeCurrentCount++;
            _currentTopNode = newNode;
        }

        //�����͸� ���������� �ϳ��� ����
        public Node<T> PopData()
        {
            //���� ž ���
            Node<T> oldTop = _currentTopNode;

            //ù��° ��带 ����
            if ( _firstNode == _currentTopNode)
            {
                _firstNode = null;
                _currentTopNode = null;
            }
            else
            {                
                Node<T> currentNode = _firstNode;

                //ž ��� ��ġ Ž������ �ݺ�
                for (int i = 0; i < _nodeCurrentCount - 1; i++)
                {           
                    if(currentNode != null &&  currentNode.nextNode != _currentTopNode) 
                    {
                        currentNode = currentNode.nextNode;
                    }                    
                }
                
                _currentTopNode = currentNode;
                currentNode.nextNode = null;
            }
            _nodeCurrentCount--;

            return oldTop;
        }

        //���� �����ִ� ������ ����
        public T GetTopData()
        {
            return _currentTopNode.nodeData;
        }

        //�����Ͱ� ����ִ��� üũ
        public bool IsEmpty()
        {
            return _nodeCurrentCount == 0;
        }

    }

    public class Study_LinkedListStack : MonoBehaviour
    {

    }
}