using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

//순환 큐(CQ : Circular Queue)

//원소를 옮기지 않고 전단(첫번째 데이터 인덱스)과 후단(마지막 데이터 인덱스)을 옮기는 큐
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

    //순환 큐를 사용하기 위한 클래스
    public class CircularQueue<T>
    {
        public int _currentQueueSize {  get; private set; }
        public int _queueCapacity { get; private set; }
        public int _frontIndex { get; private set; }
        public int _rearIndex { get; private set; }

        //각 노드들을 배열에 저장
        public Node<T>[] _nodes { get; private set; }

        public CircularQueue(int capacity)
        {
            this._nodes = new Node<T>[capacity + 1];
            _queueCapacity = capacity;
            _currentQueueSize = 0;
            _frontIndex = 0;
            _rearIndex = 0;
        }

        //큐에 하나씩 데이터 추가
        public void Enqueue(T newData)
        {
            int position;

            //후단이 큐 끝일때 순환
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

        //전단을 하나씩 이동
        public T Dequeue()
        {
            int position = _frontIndex;

            //전단이 큐 끝일때 순환
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

        //데이터가 비어있는지 체크
        public bool IsEmpty()
        {
            return _frontIndex == _rearIndex;
        }

        //데이터가 다 찼는지 체크
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