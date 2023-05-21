using UnityEngine;

//수식 트리(ET : Expression Tree)

//수식을 표현하는 이진 트리
namespace Expression.Binary.Tree
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

        //1. 루트 2. 왼쪽 하위 3. 오른쪽 하위 순으로 탐색(재귀 함수)
        public void PreorderPrintTree(Node<T> currentNode, int depth)
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

            PostorderPrintTree(currentNode.rightNode, depth + 1);

            //루트 노드 데이터 출력
            Debug.Log($"Depth: {depth}::{tap}{currentNode.nodeData}\n");
        }

        //이진 트리를 기반으로 하는 수식 트리
        public Node<T> BuildExpressionTree(T[] postfixExpression, Node<T> node, int length)
        {
            if (_indexLength == 0)
            {
                 _indexLength = length;
            }

            //문자로 된 값 토큰에 저장
            T token = postfixExpression[length - 1];

            _indexLength--;            

            //값인지 연산자인지 구별하여 트리구조 생성
            switch (token)
            {
                //연산자
                case '+': case '-': case '*': case '/':
                    node = CreateNode(token);

                    node.rightNode = BuildExpressionTree(postfixExpression, node.rightNode, _indexLength);
                    node.leftNode = BuildExpressionTree(postfixExpression, node.leftNode, _indexLength);
                    break;
                //값
                default:
                    node = CreateNode(token);
                    break;
            }

            return node;
        }

        //수식 트리 계산
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

            //트리구조 노드 데이터를 입력받아 재귀로 계산
            switch(tree.nodeData)
            {
                //연산자일때 계산
                case '+': case '-': case '*': case '/':
                    left = Evaluate(tree.leftNode);
                    right = Evaluate(tree.rightNode);

                    if (tree.nodeData == '+') result = left + right; 
                    else if (tree.nodeData == '-') result = left - right;
                    else if (tree.nodeData == '*') result = left * right;
                    else if (tree.nodeData == '/') result = left / right;
                    break;

                //값 일때 형 변환
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