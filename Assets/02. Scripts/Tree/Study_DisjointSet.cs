using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�и� ����(DS : Disjoint Set)

//�ϳ��� ������ ��尡 ���� ����
namespace Disjoint.Set
{
    //��� �����Ϳ� �θ� ��带 ������ �⺻ ���
    public class Node<T>
    { 
        public T nodeData { get; set; }
        public Node<T> parentNode { get; set; }        
    }

    //�и� ���� Ŭ����
    public class DisjointSet<T>
    {
        //�и��� ���带 �ϳ��� ���� �Լ�
        public void UnionSet(Node<T> set1, Node<T> set2)
        {
            //������ �ֻ��� �θ� ��带 Ž��
            set2 = FindSet(set2);

            set2.parentNode = set1;
        }

        //�ֻ��� �θ� ��带 ã�Ƽ� ��ȯ
        public Node<T> FindSet(Node<T> set)
        {
            if (set.parentNode == null)
            {
                return set;
            }

            set.parentNode = FindSet(set.parentNode);

            return set.parentNode;
        }

        //���ο� ������ ����
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