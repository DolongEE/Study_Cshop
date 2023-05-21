using Array.Stack;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//연결 리스트 스택 (LLS : Linked List Stack)

//연결 리스트로 구현한 스택 
namespace Linked.List.Stack
{
    //리스트의 노드 데이터 클래스
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

    //만들어진 노드 데이터를 사용하기 위한 클래스
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

        //노드 생성
        public Node<T> CreateNewNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //데이터를 순서대로 추가
        public void PushData(Node<T> newNode)
        {
            //스택이 비어있을때 새로운 노드는 첫번째 노드
            if (_firstNode == null)
            {
                _firstNode = newNode;
            }
            else
            {
                //탑 노드 위치 탐색
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

        //데이터를 위에서부터 하나씩 제거
        public Node<T> PopData()
        {
            //이전 탑 노드
            Node<T> oldTop = _currentTopNode;

            //첫번째 노드를 삭제
            if ( _firstNode == _currentTopNode)
            {
                _firstNode = null;
                _currentTopNode = null;
            }
            else
            {                
                Node<T> currentNode = _firstNode;

                //탑 노드 위치 탐색까지 반복
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

        //가장 위에있는 데이터 정보
        public T GetTopData()
        {
            return _currentTopNode.nodeData;
        }

        //데이터가 비어있는지 체크
        public bool IsEmpty()
        {
            return _nodeCurrentCount == 0;
        }

    }

    public class Study_LinkedListStack : MonoBehaviour
    {

    }
}