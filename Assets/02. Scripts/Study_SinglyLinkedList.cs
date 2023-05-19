using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글 연결 리스트(SLL : Singly Linked List)

//노드들이 한방향으로만 연결되어 있는 리스트 형식
namespace Singly.Linked.List
{
    //노드의 데이터를 저장 하기 위한 클래스
    public class SLL_Node<T>
    {
        public T nodeData { get; private set; }
        public SLL_Node<T> nextNode { get; internal set; }

        public SLL_Node(T data)
        {
            this.nodeData = data;
        }
    }

    //만들어진 노드 데이터를 사용하기 위한 클래스
    public class SinglyLinkedList<T>
    {
        public int _nodeCurrentCount;
        public SLL_Node<T> _firstNode { get; private set; }

        public SinglyLinkedList()
        {
            this._firstNode = null;
        }

        private SLL_Node<T> CreateNewNode(T newData)
        {
            //새로운 노드를 담는 지역변수
            SLL_Node<T> tempNewNode = new SLL_Node<T>(newData);

            //리스트에 노드가 없을 시 처음 노드 할당
            if (_firstNode == null)
            {
                _firstNode = tempNewNode;
            }

            _nodeCurrentCount++;

            return tempNewNode;
        }

        public SLL_Node<T> FindIndexNode(int index)
        {
            //노드가 없으므로 실행 실패
            if (_firstNode == null)
            {
                Debug.LogError("노드가 없습니다");
                return null;
            }

            //indexNode(찾기 원하는 노드)에 첫번째 노드 대입 
            SLL_Node<T> indexNode = _firstNode;
            //원하는 노드를 찾을때까지 indexNode에 다음 노드 저장시키며 반복
            for (int i = 0; i < index; i++)
            {
                indexNode = indexNode.nextNode;
            }

            return indexNode;
        }

        public void AddFirstNode(T newData)
        {
            //새로운 노드를 담는 지역변수
            SLL_Node<T> tempNewNode = CreateNewNode(newData);

            //첫번 째 노드를 tempNewNode(새로운 노드)로 변경
            tempNewNode.nextNode = _firstNode;
            _firstNode = tempNewNode;
        }

        public void AddEndNode(T newData)
        {
            //새로운 노드를 담는 지역변수
            SLL_Node<T> tempNewNode = CreateNewNode(newData);

            //맨 뒤에 있는 노드(Tail)를 찾는 for문 
            SLL_Node<T> Tail = _firstNode;
            for (int i = 0; i < _nodeCurrentCount && Tail.nextNode != null; i++)
            {
                Tail = Tail.nextNode;
            }

            //제일 뒤에 있는 노드를 변경
            Tail.nextNode = tempNewNode;
        }

        public void InsertNodeBefore(int index, T newData)
        {
            //노드 최대 개수 범위에 없으므로 실행 실패
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("노드가 없습니다");
                return;
            }

            //index = 0은 첫 번째 노드를 뜻하므로 해당 함수 실행
            if (index == 0)
            {
                AddFirstNode(newData);
                return;
            }
            //index가 노드 수랑 같을 경우 맨뒤에 추가하는 함수 실행
            else if (index == _nodeCurrentCount - 1)
            {
                AddEndNode(newData);
                return;
            }

            //새로운 노드를 담는 지역변수
            SLL_Node<T> tempNewNode = CreateNewNode(newData);
            //데이터를 추가할 위치의 노드를 담는 지역변수
            SLL_Node<T> indexNode = FindIndexNode(index - 1);

            //index위치에 tempNewNode데이터 삽입
            tempNewNode.nextNode = indexNode.nextNode;
            indexNode.nextNode = tempNewNode;

        }

        public void InsertNodeAfter(int index, T newData)
        {
            //삽입 노드의 위치가 후위로 변경
            InsertNodeBefore(index + 1, newData);
        }             

        public T GetNodeData(int index)
        {
            //노드 최대 개수 범위에 없으므로 실행 실패
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("노드가 없습니다");
                return default;
            }

            SLL_Node<T> wantNode = FindIndexNode(index);

            return wantNode.nodeData;
        }

        public void RemoveIndexNode(int index)
        {
            //노드 최대 개수 범위에 없으므로 실행 실패
            if (index > _nodeCurrentCount)
            {
                Debug.LogError("노드가 없습니다");
                return;
            }            

            SLL_Node<T> removeNode = FindIndexNode(index);

            if (removeNode == _firstNode)
            {
                _firstNode = removeNode.nextNode;
            }
            else
            {
                //지우려는 노드 앞뒤 노드 서로 연결
                SLL_Node<T> prevNode = FindIndexNode(index - 1);
                prevNode.nextNode = removeNode.nextNode;
            }
            _nodeCurrentCount--;
        }

        public void RemoveAllNode()
        {
            //노드가 없으므로 실행 실패
            if (_nodeCurrentCount == 0)
            {
                Debug.LogError("노드가 없습니다");
                return;
            }

            //리스트에 있는 노드가 0개 일때까지 삭제
            for (int i = _nodeCurrentCount; i == 0; i--)
            {
                RemoveIndexNode(0);
            }
        }
    }

    public class Study_SinglyLinkedList : MonoBehaviour
    {

    }
}