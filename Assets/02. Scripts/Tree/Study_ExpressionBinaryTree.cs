using UnityEngine;

//���� Ʈ��(ET : Expression Tree)

//������ ǥ���ϴ� ���� Ʈ��
namespace Expression.Binary.Tree
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
            rightNode = null;
            leftNode = null;
            nodeData = data;
        }
    }

    public class ExpressionBinaryTree<T>
    {
        public int _indexLength {  get; set; }

        public Node<T> CreateNode(T newData)
        {
            Node<T> newNode = new Node<T>(newData);

            return newNode;
        }

        //1. ��Ʈ 2. ���� ���� 3. ������ ���� ������ Ž��(��� �Լ�)
        public void PreorderPrintTree(Node<T> currentNode, int depth)
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

            PostorderPrintTree(currentNode.rightNode, depth + 1);

            //��Ʈ ��� ������ ���
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
        }

        //���� Ʈ���� ������� �ϴ� ���� Ʈ��
        public Node<T> BuildExpressionTree(T[] postfixExpression, Node<T> node, int length)
        {
            if (_indexLength == 0)
            {
                 _indexLength = length;
            }

            //���ڷ� �� �� ��ū�� ����
            T token = postfixExpression[length - 1];

            _indexLength--;            

            //������ ���������� �����Ͽ� Ʈ������ ����
            switch (token)
            {
                //������
                case '+': case '-': case '*': case '/':
                    node = CreateNode(token);

                    node.rightNode = BuildExpressionTree(postfixExpression, node.rightNode, _indexLength);
                    node.leftNode = BuildExpressionTree(postfixExpression, node.leftNode, _indexLength);
                    break;
                //��
                default:
                    node = CreateNode(token);
                    break;
            }

            return node;
        }

        //���� Ʈ�� ���
        public double Evaluate(Node<char> tree)
        {
            char[] temp = new char[2];

            double left = 0;
            double right = 0;
            double result = 0;

            if (tree == null)
            {
                return 0;
            }

            //Ʈ������ ��� �����͸� �Է¹޾� ��ͷ� ���
            switch(tree.nodeData)
            {
                //�������϶� ���
                case '+': case '-': case '*': case '/':
                    left = Evaluate(tree.leftNode);
                    right = Evaluate(tree.rightNode);

                    if (tree.nodeData == '+') result = left + right; 
                    else if (tree.nodeData == '-') result = left - right;
                    else if (tree.nodeData == '*') result = left * right;
                    else if (tree.nodeData == '/') result = left / right;
                    break;

                //�� �϶� �� ��ȯ
                default:
                    temp[0] = tree.nodeData;
                    result = double.Parse(new string(temp));

                    break;
            }

            return result;
        }
    }

    public class Study_ExpressionBinaryTree : MonoBehaviour
    {
        
    }
}