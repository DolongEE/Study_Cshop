using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ť(LQ : Linked Queue)

//�� ���� �� ��带 �̾� ���� ť �뷮�� ������ ����
namespace Linked.Queue
{
    //����� ������ ����
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

    //���� ť�� ����ϱ� ���� Ŭ����
    public class LinkedQueue<T>
    {
        public int _currentCount {  get; set; }
        public Node<T> _frontNode { get;  set; }
        public Node<T> _rearNode { get;  set; }

        public LinkedQueue()
        {
            _frontNode = null;
            _rearNode = null;
        }

        //ť�� �ϳ��� ������ �߰�
        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);

            //��� ���� ����
            if (_frontNode == null)
            {
                _frontNode = newNode;
                _rearNode = newNode;
            }
            else
            {
                _rearNode.nextNode = newNode;
                _rearNode = newNode;
            }

            _currentCount++;
        }

        //������ �ϳ��� �̵�
        public Node<T> Dequeue()
        {
            //������ ������ ť�� ����ִ�
            if (_frontNode == null)
            {
                Debug.Log("ť�� ������ϴ�.");
                return default(Node<T>);
            }

            //���� ��� ����� ���� ��� ���� ����
            Node<T> oldNode = _frontNode;

            //������ ���� ť�� ���� �� ť�� ����ִ�
            if(_frontNode.nextNode == null)
            {
                _frontNode = null;
                _rearNode = null;
            }
            else
            {
                _frontNode = _frontNode.nextNode;
            }

            _currentCount--;
            return oldNode;
        }

        //ť�� ����ִ��� Ȯ��
        public bool IsEmpty()
        {
            return _frontNode == null;
        }
    }

    public class Study_LinkedQueue : MonoBehaviour
    {
        
    }
}