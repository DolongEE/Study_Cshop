using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

//�迭 ���� (AS : Array Stack)

//�迭�� ������ ���� 
namespace Array.Stack
{
    //�迭 ������ ������ Ŭ����
    public class Node<T>
    {
        public T nodeData { get; set; }

        public Node(T data)
        {
            this.nodeData = data;
        }
    }

    //��� �����͸� ���� ��Ű�� ���� Ŭ����
    public class AS_ArrayStack<T>
    {
        public int _stackSize { get; private set; }

        //���� ���� �����ִ� ��� �ε���
        public int _currentTopIndex { get; private set; }

        //��带 �迭�� ����
        public Node<T>[] _nodes { get; private set; }

        public AS_ArrayStack(int size)
        {
            _nodes = new Node<T>[size];
            _stackSize = size;
            _currentTopIndex = 0;
        }

        //�����͸� ������� �߰�
        public void PushData(T newData)
        {
            //������ ��á���� ��ȯ
            if (_currentTopIndex == _stackSize - 1)
            {
                Debug.LogError("������ �� á���ϴ�.");
                return;
            }

            //���ο� �����͸� ���� ��� �߰�
            Node<T> newNode = new Node<T>(newData);

            _nodes[_currentTopIndex++] = newNode;
        }

        //�����͸� ���������� �ϳ��� ����
        public T PopData()
        {
            //������ ��������� ��ȯ
            if (_currentTopIndex == 0)
            {
                Debug.LogError("������ ������ϴ�.");
                return default;
            }

            return _nodes[--_currentTopIndex].nodeData;
        }

        //���� �����ִ� ������ ����
        public T GetTopData()
        {
            //������ ��������� ��ȯ
            if (_currentTopIndex == 0)
            {
                Debug.LogError("������ ������ϴ�.");
                return default;
            }

            return _nodes[_currentTopIndex - 1].nodeData;
        }

        //�����Ͱ� ����ִ��� üũ
        public bool IsEmpty()
        {
            return _currentTopIndex == 0;
        }

    }

    public class Study_ArrayStack : MonoBehaviour
    {

    }
}



