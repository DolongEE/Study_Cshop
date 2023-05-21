using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

//��ȯ ť(CQ : Circular Queue)

//���Ҹ� �ű��� �ʰ� ����(ù��° ������ �ε���)�� �Ĵ�(������ ������ �ε���)�� �ű�� ť
namespace Circular.Queue
{
    public class Node<T>
    {        
        public T nodeData { get; set; }

        public Node(T data)
        {
            this.nodeData = data;
        }
    }

    //��ȯ ť�� ����ϱ� ���� Ŭ����
    public class CircularQueue<T>
    {
        public int _currentQueueSize {  get; private set; }
        public int _queueCapacity { get; private set; }
        public int _frontIndex { get; private set; }
        public int _rearIndex { get; private set; }

        //�� ������ �迭�� ����
        public Node<T>[] _nodes { get; private set; }

        public CircularQueue(int capacity)
        {
            this._nodes = new Node<T>[capacity + 1];
            _queueCapacity = capacity;
            _currentQueueSize = 0;
            _frontIndex = 0;
            _rearIndex = 0;
        }

        //ť�� �ϳ��� ������ �߰�
        public void Enqueue(T newData)
        {
            int position;

            //�Ĵ��� ť ���϶� ��ȯ
            if (_rearIndex == _queueCapacity)
            {
                position = _rearIndex;
                _rearIndex = 0;
            }
            else
            {
                position = _rearIndex++;
            }

            _currentQueueSize++;

            _nodes[position] = new Node<T>(newData);
        }

        //������ �ϳ��� �̵�
        public T Dequeue()
        {
            int position = _frontIndex;

            //������ ť ���϶� ��ȯ
            if( _frontIndex == _queueCapacity)
            {
                _frontIndex = 0;
            }
            else
            {
                _frontIndex++;
            }

            _currentQueueSize--;

            return _nodes[position].nodeData;
        }

        //�����Ͱ� ����ִ��� üũ
        public bool IsEmpty()
        {
            return _frontIndex == _rearIndex;
        }

        //�����Ͱ� �� á���� üũ
        public bool IsCapacityFull()
        {
            if(_frontIndex < _rearIndex)
            {
                return _rearIndex - _frontIndex == _queueCapacity;
            }
            else
            {
                return _rearIndex + 1 == _frontIndex;
            }
        }
    }

    public class Study_CircularQueue : MonoBehaviour
    {
        
    }
}