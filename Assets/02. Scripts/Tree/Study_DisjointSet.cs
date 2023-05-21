using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//분리 집합(DS : Disjoint Set)

//하나의 동일한 노드가 없는 집합
namespace Disjoint.Set
{
    //노드 데이터와 부모 노드를 가지는 기본 노드
    public class Node<T>
    { 
        public T nodeData { get; set; }
        public Node<T> parentNode { get; set; }        
    }

    //분리 집합 클래스
    public class DisjointSet<T>
    {
        //분리된 노드드를 하나로 묶는 함수
        public void UnionSet(Node<T> set1, Node<T> set2)
        {
            //집합의 최상위 부모 노드를 탐색
            set2 = FindSet(set2);

            set2.parentNode = set1;
        }

        //최상위 부모 노드를 찾아서 반환
        public Node<T> FindSet(Node<T> set)
        {
            if (set.parentNode == null)
            {
                return set;
            }

            set.parentNode = FindSet(set.parentNode);

            return set.parentNode;
        }

        //새로운 집합을 생성
        public Node<T> MakeSet(T newData)
        {
            Node<T> newNode = new Node<T>();
            newNode.nodeData = newData;
            newNode.parentNode = null;

            return newNode;
        }
    }
    
    public class Study_DisjointSet : MonoBehaviour
    {
        
    }
}