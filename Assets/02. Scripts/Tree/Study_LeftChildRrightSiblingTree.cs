using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//왼쪽 자식 오른쪽 형제 트리 구조(LCRS Tree : Left Child Right Sibling Tree)

//왼쪽에는 자식 노드가 오른쪽에는 형제 노드가 이어지는 트리 구조
namespace LeftChild.RightSibling.Tree
{
    //트리 구조의 요소인 노드 정보
    public class Node<T>
    {
        //형제 노드의 가장 끝을 알기위한 정수
        public int siblingCount { get; set; }

        public T nodeData { get; set; }

        public Node<T> leftChild { get; set; }
        public Node<T> rightSibling { get; set; }

        public Node(T data)
        {
            this.siblingCount = 0;
            this.nodeData = data;
            
            leftChild = null;
            rightSibling = null;
        }
    }

    public class LeftChildRrightSiblingTree<T>
    {
        //노드를 생성
        public Node<T> CreateNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //부모 노드와 자식 노드 설정
        public void AddChildNode(Node<T> parentNode, Node<T> childNode) 
        {
            //부모노드에 자식노드가 없을때 자식노드로 추가
            if (parentNode.leftChild == null)
            {
                parentNode.leftChild = childNode;
                parentNode.siblingCount++;
            }
            //부모노드에 자식노드가 한개라도 있을때 형제노드로 추가
            else
            {
                //마지막 형제 노드를 찾을 때 까지 반복
                Node<T> tempNode = parentNode.leftChild;

                for(int i = 0; i < parentNode.siblingCount; i++)
                {
                    if(tempNode.rightSibling != null)
                    {
                        tempNode = tempNode.rightSibling;
                    }
                }

                tempNode.rightSibling = childNode;
            }
        }

        //트리 구조 출력
        public void PrintTree(Node<T> currentNode, int depth)
        {
            //깊이에 따라 탭
            string tap = new string('\t', depth);

            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
            
            //현재 노드에 자식 노드가 있을시 재귀
            if (currentNode.leftChild != null)
            {
                PrintTree(currentNode.leftChild, depth + 1);
            }
            //현재 노드에 형제 노드가 있을시 재귀
            if(currentNode.rightSibling != null)
            {
                PrintTree(currentNode.rightSibling, depth);
            }            
        }
    }


    public class Study_LeftChildRrightSiblingTree : MonoBehaviour
    {

    }
}