using Circular.Doubly.Linked.List;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//이중 연결 리스트(DLL : Doubly Linked List)

//노드들이 양방향으로 연결되어 있는 리스트 형식
namespace Doubly.Linked.List
{
    //노드의 데이터를 저장 하기 위한 클래스
    public class DLL_Node<T>
    {
        public T nodeData { get; set; }
        public DLL_Node<T> prevNode { get; set; }
        public DLL_Node<T> nextNode { get; set; }
    }

    //만들어진 노드 데이터를 사용하기 위한 클래스
    public class DLL_LinkedList<T>
    {
        public int _nodeCurrentCount;

        //리스트 첫 번째에 있는 노드 정보
        public DLL_Node<T> _firstNode { get; private set; }

        public DLL_LinkedList()
        {
            this._firstNode = null;
        }

        //새로운 노드 생성 함수
        public DLL_Node<T> CreateNewNode(T newData)
        {
            //노드 생성
            DLL_Node<T> tempNewNode = new DLL_Node<T>();

            //생성된 노드 초기화
            tempNewNode.nodeData = newData;
            tempNewNode.prevNode = null;
            tempNewNode.nextNode = null;

            return tempNewNode;
        }

        //노드 순차적으로 추가 함수
        public void AppendNode(DLL_Node<T> newNode)
        {
            //첫번째 노드가 없으면 새로운 노드가 첫번째 노드
            if(_firstNode == null)
            {
                _firstNode = newNode;
            }
            else
            {
                //맨뒤 노드를 첫번째 노드부터 순차적으로 탐색
                DLL_Node<T> lastNode = _firstNode;
                for(int i = 0; i< _nodeCurrentCount - 1 ; i++)
                {
                    lastNode = lastNode.nextNode;
                    if(lastNode.nextNode == null) 
                    {
                        break;
                    }
                }

                lastNode.nextNode = newNode;
                newNode.prevNode = lastNode;
            }

            _nodeCurrentCount++;
        }

        //기존노드 뒤에 새로운 노드 삽입 함수
        public void InsertAfter(DLL_Node<T> current, DLL_Node<T> newNode)
        {
            newNode.nextNode = current.nextNode;
            newNode.prevNode = current;

            //현재 노드 뒤에 노드가 있다면 뒤 노드 정보 업데이트
            if (current.nextNode != null)
            {
                current.nextNode.prevNode = newNode;
            }
            _nodeCurrentCount++;
            current.nextNode = newNode;
        }

        //노드 제거 함수
        public void RemoveNode(DLL_Node<T> removeNode)
        {
            //지우려는 노드가 첫번째 노드 일 경우
            if(_firstNode == removeNode)
            {
                //첫번째 노드 정보 업데이트(첫번째 노드에 null이 들어갈수도 있음)
                _firstNode = removeNode.nextNode;

                //리스트에 첫번째 노드가 남아 있을때 정보 업데이트
                if(_firstNode != null)
                {
                    _firstNode.prevNode = null;
                }
            }
            else
            {
                //지울 노드 앞 뒤 노드 정보 업테이트를 위해 지울 노드 정보 복사
                DLL_Node<T> temp = removeNode;

                //지울 노드의 앞 노드가 있을때 앞 노드 업데이트
                if(removeNode.prevNode != null)
                {
                    removeNode.prevNode.nextNode = temp.nextNode;
                }

                //지울 노드의 뒤 노드가 있을때 뒤 노드 업데이트
                if(removeNode.nextNode != null)
                {
                    removeNode.nextNode.prevNode = temp.prevNode;
                }
            }
            _nodeCurrentCount--;
            removeNode.prevNode = null;
            removeNode.nextNode = null;
        }

        //노드 위치 탐색 함수
        public DLL_Node<T> GetNodeAt(int index)
        {
            //노드를 찾기위해 첫번째 노드 할당
            DLL_Node<T> currentNode = _firstNode;

            //찾으려는 노드 위치만큼 반복
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.nextNode;
            }

            return currentNode;
        }
    }


    public class Study_DoublyLinkedList : MonoBehaviour
    {
      
    }
}