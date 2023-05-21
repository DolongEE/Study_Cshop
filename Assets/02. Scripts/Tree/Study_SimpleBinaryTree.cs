using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//단순 이진 트리(SBT : Simple Binary Tree)

//모든 노드가 최대 2개의 자식 노드를 가지는 트리 구조
namespace Simple.Binary.Tree
{
    //기본 노드 정보
    public class Node<T>
    {
        public T nodeData { get; set; }

        //하위 왼쪽 노드
        public Node<T> leftNode { get; set; }

        //하위 오른쪽 노드
        public Node<T> rightNode { get; set; }

        public Node(T data)
        {
            leftNode = null;
            rightNode = null;
            nodeData = data;
        }
    }

    //이진 트리 구조 클래스
    public class SimpleBinaryTree<T>
    {
        public Node<T> CreateNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //1. 루트 2. 왼쪽 하위 3. 오른쪽 하위 순으로 탐색(재귀 함수)
        public void PreorderPrintTree(Node<T> currentNode,int depth)
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            //루트 노드 데이터 출력
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");

            PreorderPrintTree(currentNode.leftNode, depth + 1);

            PreorderPrintTree(currentNode.rightNode, depth + 1);
        }

        //1. 왼쪽 하위 2. 루트 3. 오른쪽 하위 순으로 탐색(재귀 함수)
        public void InorderPrintTree(Node<T> currentNode, int depth) 
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            InorderPrintTree(currentNode.leftNode, depth + 1);

            //루트 노드 데이터 출력
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");

            InorderPrintTree(currentNode.rightNode, depth + 1);
        }

        //1. 왼쪽 하위 2. 오른쪽 하위 3. 루트 순으로 탐색(재귀 함수)
        public void PostorderPrintTree(Node<T> currentNode, int depth)
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            PostorderPrintTree(currentNode.leftNode, depth + 1);

            PostorderPrintTree(currentNode.rightNode, depth +1);

            //루트 노드 데이터 출력
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
        }
    }


    public class Study_SimpleBinaryTree : MonoBehaviour
    {
        
    }
}


