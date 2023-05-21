using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

//배열 스택 (AS : Array Stack)

//배열로 구현한 스택 
namespace Array.Stack
{
    //배열 원소의 데이터 클래스
    public class Node<T>
    {
        public T nodeData { get; set; }

        public Node(T data)
        {
            this.nodeData = data;
        }
    }

    //노드 데이터를 저장 시키기 위한 클래스
    public class AS_ArrayStack<T>
    {
        public int _stackSize { get; private set; }

        //현재 가장 위에있는 노드 인덱스
        public int _currentTopIndex { get; private set; }

        //노드를 배열로 저장
        public Node<T>[] _nodes { get; private set; }

        public AS_ArrayStack(int size)
        {
            _nodes = new Node<T>[size];
            _stackSize = size;
            _currentTopIndex = 0;
        }

        //데이터를 순서대로 추가
        public void PushData(T newData)
        {
            //스택이 다찼을때 반환
            if (_currentTopIndex == _stackSize - 1)
            {
                Debug.LogError("스택이 다 찼습니다.");
                return;
            }

            //새로운 데이터를 가진 노드 추가
            Node<T> newNode = new Node<T>(newData);

            _nodes[_currentTopIndex++] = newNode;
        }

        //데이터를 위에서부터 하나씩 제거
        public T PopData()
        {
            //스택이 비어있을때 반환
            if (_currentTopIndex == 0)
            {
                Debug.LogError("스택이 비었습니다.");
                return default;
            }

            return _nodes[--_currentTopIndex].nodeData;
        }

        //가장 위에있는 데이터 정보
        public T GetTopData()
        {
            //스택이 비어있을때 반환
            if (_currentTopIndex == 0)
            {
                Debug.LogError("스택이 비었습니다.");
                return default;
            }

            return _nodes[_currentTopIndex - 1].nodeData;
        }

        //데이터가 비어있는지 체크
        public bool IsEmpty()
        {
            return _currentTopIndex == 0;
        }

    }

    public class Study_ArrayStack : MonoBehaviour
    {

    }
}



