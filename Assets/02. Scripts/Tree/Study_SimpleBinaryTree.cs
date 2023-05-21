using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ܼ� ���� Ʈ��(SBT : Simple Binary Tree)

//��� ��尡 �ִ� 2���� �ڽ� ��带 ������ Ʈ�� ����
namespace Simple.Binary.Tree
{
    //�⺻ ��� ����
    public class Node<T>
    {
        public T nodeData { get; set; }

        //���� ���� ���
        public Node<T> leftNode { get; set; }

        //���� ������ ���
        public Node<T> rightNode { get; set; }

        public Node(T data)
        {
            leftNode = null;
            rightNode = null;
            nodeData = data;
        }
    }

    //���� Ʈ�� ���� Ŭ����
    public class SimpleBinaryTree<T>
    {
        public Node<T> CreateNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //1. ��Ʈ 2. ���� ���� 3. ������ ���� ������ Ž��(��� �Լ�)
        public void PreorderPrintTree(Node<T> currentNode,int depth)
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            //��Ʈ ��� ������ ���
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");

            PreorderPrintTree(currentNode.leftNode, depth + 1);

            PreorderPrintTree(currentNode.rightNode, depth + 1);
        }

        //1. ���� ���� 2. ��Ʈ 3. ������ ���� ������ Ž��(��� �Լ�)
        public void InorderPrintTree(Node<T> currentNode, int depth) 
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            InorderPrintTree(currentNode.leftNode, depth + 1);

            //��Ʈ ��� ������ ���
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");

            InorderPrintTree(currentNode.rightNode, depth + 1);
        }

        //1. ���� ���� 2. ������ ���� 3. ��Ʈ ������ Ž��(��� �Լ�)
        public void PostorderPrintTree(Node<T> currentNode, int depth)
        {
            if (currentNode == null)
            {
                return;
            }

            string tap = new string('\t', depth);

            PostorderPrintTree(currentNode.leftNode, depth + 1);

            PostorderPrintTree(currentNode.rightNode, depth +1);

            //��Ʈ ��� ������ ���
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
        }
    }


    public class Study_SimpleBinaryTree : MonoBehaviour
    {
        
    }
}


