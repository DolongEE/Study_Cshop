using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �ڽ� ������ ���� Ʈ�� ����(LCRS Tree : Left Child Right Sibling Tree)

//���ʿ��� �ڽ� ��尡 �����ʿ��� ���� ��尡 �̾����� Ʈ�� ����
namespace LeftChild.RightSibling.Tree
{
    //Ʈ�� ������ ����� ��� ����
    public class Node<T>
    {
        //���� ����� ���� ���� �˱����� ����
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
        //��带 ����
        public Node<T> CreateNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //�θ� ���� �ڽ� ��� ����
        public void AddChildNode(Node<T> parentNode, Node<T> childNode) 
        {
            //�θ��忡 �ڽĳ�尡 ������ �ڽĳ��� �߰�
            if (parentNode.leftChild == null)
            {
                parentNode.leftChild = childNode;
                parentNode.siblingCount++;
            }
            //�θ��忡 �ڽĳ�尡 �Ѱ��� ������ �������� �߰�
            else
            {
                //������ ���� ��带 ã�� �� ���� �ݺ�
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

        //Ʈ�� ���� ���
        public void PrintTree(Node<T> currentNode, int depth)
        {
            //���̿� ���� ��
            string tap = new string('\t', depth);

            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
            
            //���� ��忡 �ڽ� ��尡 ������ ���
            if (currentNode.leftChild != null)
            {
                PrintTree(currentNode.leftChild, depth + 1);
            }
            //���� ��忡 ���� ��尡 ������ ���
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