using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//연결 큐(LQ : Linked Queue)

//앞 노드와 뒷 노드를 이어 만든 큐 용량의 제한이 없다
namespace Linked.Queue
{
    //노드의 데이터 정보
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

    //연결 큐를 사용하기 위한 클래스
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

        //큐에 하나씩 데이터 추가
        public void Enqueue(T data)
        {
            Node<T> newNode = new Node<T>(data);

            //노드 새로 생성
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

        //전단을 하나씩 이동
        public Node<T> Dequeue()
        {
            //전단이 없으면 큐가 비어있다
            if (_frontNode == null)
            {
                Debug.Log("큐가 비었습니다.");
                return default(Node<T>);
            }

            //이전 노드 출력을 위한 노드 정보 복사
            Node<T> oldNode = _frontNode;

            //전단의 다음 큐가 없을 때 큐는 비어있다
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

        //큐가 비어있는지 확인
        public bool IsEmpty()
        {
            return _frontNode == null;
        }
    }

    public class Study_LinkedQueue : MonoBehaviour
    {
        
    }
}