using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//환형 이중 연결 리스트(CDLL : Circular Doubly Linked List)

//노드들이 양방향 & 앞뒤가 연결 되어 있는 리스트 형식
namespace Circular.Doubly.Linked.List
{
    //노드의 데이터를 저장 하기 위한 클래스
    public class CDLL_Node<T>
    {
        public T nodeData { get; set; }
        public CDLL_Node<T> prevNode { get; set; }
        public CDLL_Node<T> nextNode { get; set; }
    }

    //만들어진 노드 데이터를 사용하기 위한 클래스
    public class CircularDoublyLinkedList<T>
    {
        public int _nodeCurrentCount;

        //리스트 첫번째에 있는 노드 정보
        public CDLL_Node<T> _firstNode { get; private set; }

        //새로운 노드 생성 함수
        public CDLL_Node<T> CreateNewNode(T newData)
        {
            //노드 생성
            CDLL_Node<T> newNode = new CDLL_Node<T>();

            newNode.nodeData = newData;
            newNode.prevNode = null;
            newNode.nextNode = null;

            return newNode;
        }

        //리스트에 노드 추가 함수
        public void AppendNode(CDLL_Node<T> newNode)
        {
            //새로운 노드를 첫번째 노드가 없을때 첫번째 노드에 정보 저장
            if (_firstNode == null)
            {
                _firstNode = newNode;

                //첫번째 노드가 자기 자신을 가리키도록 정보 업데이트(꼬리 물기)
                _firstNode.nextNode = _firstNode;
                _firstNode.prevNode = _firstNode;
            }
            else
            {
                //마지막 노드를 의미함
                CDLL_Node<T> tail = _firstNode.prevNode;

                tail.nextNode.prevNode = newNode;
                tail.nextNode = newNode;

                newNode.nextNode = _firstNode;
                newNode.prevNode = tail;
            }
            _nodeCurrentCount++;
        }

        //기존노드 뒤에 새로운 노드 삽입 함수
        public void InsertAfter(CDLL_Node<T> currentNode, CDLL_Node<T> newNode)
        {
            newNode.nextNode = currentNode.nextNode;
            newNode.prevNode = currentNode;

            //현재 노드의 뒤 노드 정보 업데이트
            currentNode.nextNode.prevNode = newNode;

            currentNode.nextNode = newNode;

            _nodeCurrentCount++;
        }

        //노드 제거 함수
        public void RemoveNode(CDLL_Node<T> removeNode)
        {
            //첫번째 노드를 지울경우
            if (_firstNode == removeNode)
            {
                //마지막 노드가 첫번째 노드의 다음 노드를 가리키게 정보 업데이트
                _firstNode.prevNode.nextNode = removeNode.nextNode;

                //첫번째 노드의 다음 노드가 마지막 노드를 가리키게 정보 업데이트
                _firstNode.nextNode.prevNode = removeNode.prevNode;
                                
                _firstNode = removeNode.nextNode;
            }
            else
            {
                //지울 노드 앞 뒤 노드 정보 업테이트를 위해 지울 노드 정보 복사
                CDLL_Node<T> temp = removeNode;

                //지울 노드의 앞 노드가 뒤 노드를 가리키게 정보 업데이트
                removeNode.prevNode.nextNode = temp.nextNode;

                //지울 노드의 뒤 노드가 앞 노드를 가리키게 정보 업데이트
                removeNode.nextNode.prevNode = temp.prevNode;
            }            
            removeNode.prevNode = null;
            removeNode.nextNode = null;

            _nodeCurrentCount--;
        }

        //노드 위치 탐색 함수
        public CDLL_Node<T> GetNodeAt(int index)
        {
            //노드를 찾기위해 첫번째 노드 할당
            CDLL_Node<T> currentNode = _firstNode;

            //찾으려는 노드 위치만큼 반복
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