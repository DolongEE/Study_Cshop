using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SLL_Node<T>
{
    public T sll_Data { get; internal set; }
    public SLL_Node<T> NextNode { get; internal set; }

    public SLL_Node(T data)
    {
        this.sll_Data = data;
    }
}

public class DLL_Node<T>
{
    public T dll_Data { get; internal set; }
    public DLL_Node<T> PrevNode { get; internal set; }
    public DLL_Node<T> NextNode { get; internal set; }
    
    public DLL_Node(T data)
    {
        this.dll_Data = data;
    }
}
public class SLL_LinkedList<T>
{
    public SLL_Node<T> Head_sll { get; set; }
    public int sll_nodeCount;

    public SLL_LinkedList() 
    {
        this.Head_sll = null;
    }

    
    private SLL_Node<T> CreateNode(T data)
    {
        SLL_Node<T> newNode = new SLL_Node<T>(data);
        if(Head_sll == null) 
        {
            Head_sll = newNode;
        }
        sll_nodeCount++;
        return newNode;
    }

    public void AddFirst(T newData)
    {
        SLL_Node<T> newNode = CreateNode(newData);

        newNode.NextNode = Head_sll;
        Head_sll = newNode;

        //Debug.Log($"List[0] 맨 앞 Data : {newData}");
    }

    public void AddLast(T newData)
    {
        SLL_Node<T> newNode = CreateNode(newData);

        SLL_Node<T> Tail = Head_sll;
        for (int i = 0; i < sll_nodeCount && Tail.NextNode != null; i++)
        {
            Tail = Tail.NextNode;
        }
        Tail.NextNode = newNode;
        //Debug.Log($"List[{nodeCount}] 맨뒤 Data : {newData}");
    }

    public SLL_Node<T> FindNode(int index)
    {        
        if (Head_sll == null)
        {
            Debug.LogError("노드 없음");
            return null;
        }

        SLL_Node<T> currentNode = Head_sll;

        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.NextNode;
        }
       // Debug.Log($"List[{index}] 중간 Data : {currentNode.Data} 찾음");
        return currentNode;
    }


    public void InsertBeforeNode(int index, T newData)
    {
        if (index > sll_nodeCount - 1)
        {
            Debug.LogError("잘못된 위치");
            return;
        }

        SLL_Node<T> newNode = CreateNode(newData);

        if (index == 0)
        {
            sll_nodeCount--;
            AddFirst(newData);
            return;
        }
        else if (index == sll_nodeCount - 1)
        {
            sll_nodeCount--;
            AddLast(newData);
            return;
        }

        SLL_Node<T> currentNode = FindNode(index - 1);

        newNode.NextNode = currentNode.NextNode;
        currentNode.NextNode = newNode;

        //Debug.Log($"List[{index}] 중간 Data : {newData} 추가");
    }

    public void InsertAfterNode(int index, T newData)
    {
        InsertBeforeNode(index + 1, newData);
    }

    public void RemoveNode(int index)
    {
        if (index > sll_nodeCount - 1)
        {
            Debug.LogError("잘못된 위치");
            return;
        }

        SLL_Node<T> removeNode = FindNode(index);

        //Debug.Log($"List[{index}] 중간 Data : {removeNode.sll_Data} 제거");
        if (removeNode == Head_sll)
        {
            Debug.Log("머리임");
            Head_sll = removeNode.NextNode;
        }
        else
        {
            SLL_Node<T> prevNode = FindNode(index - 1);
            prevNode.NextNode = removeNode.NextNode;
        }
        sll_nodeCount--;
    }

    public void RemoveAllNode()
    {
        SLL_Node<T> currentHead = Head_sll;
        if(sll_nodeCount == 0)
        {
            return;
        }

        for (; sll_nodeCount != 0 ; )
        {
            RemoveNode(0);
            Debug.Log("삭제삭제");
        }

    }

    
}

public class DLL_LinkedList<T>
{
    public DLL_Node<T> Head_dll { get; set; }
    public DLL_Node<T> Tail_dll { get; set; }

    public int dll_nodeCount;

    public DLL_LinkedList()
    {
        this.Head_dll = null;
        this.Tail_dll = null;
    }

    private DLL_Node<T> CreateNode(T data)
    {
        DLL_Node<T> newNode = new DLL_Node<T>(data);

        newNode.PrevNode = null;
        newNode.NextNode = null;
        dll_nodeCount++;
        return newNode;
    }

    public void AddFirst(T data)
    {
        DLL_Node<T> newNode = CreateNode(data);
        if(Head_dll == null)
        {
            Head_dll = newNode;
            Tail_dll = newNode;
        }
        else
        {
            newNode.NextNode = Head_dll.PrevNode;
            Head_dll.PrevNode = 
            Head_dll = newNode;
        }      
    }

    public void AddLast(T data) 
    {
        DLL_Node<T> newNode = CreateNode(data);
        if(Head_dll == null)
        {
            Head_dll = newNode;
            Tail_dll = newNode;
        }
        else
        {
            newNode.PrevNode = Tail_dll.NextNode;
            Tail_dll.NextNode = newNode.PrevNode;
            Tail_dll = newNode;
        }
        
    }

    public DLL_Node<T> FindNode(int index)
    {
        if(Head_dll == null)
        {
            Debug.LogError("노드 없음");
            return null;
        }
        else if(index > dll_nodeCount)
        {
            Debug.LogError("범위 넘김");
        }

        DLL_Node<T> currentNode = Head_dll;
        
        for (int i = 0; i < index; i++) 
        {
            currentNode.PrevNode = currentNode.NextNode;
            Debug.Log($"Data : {currentNode.dll_Data} 찾음");
        }
        //Debug.Log($"List[{index}] 중간 Data : {currentNode.dll_Data} 찾음");
        return currentNode;
    }

}


public class Study_SLL_LinkedList : MonoBehaviour
{
    SLL_LinkedList<int> sll = new SLL_LinkedList<int>();
    DLL_LinkedList<int> dll = new DLL_LinkedList<int>();

    private void Start()
    {
        //sll.AddFirst(3);
        //sll.AddLast(2);
        //sll.AddLast(4);
        //sll.AddLast(5);
        //sll.AddFirst(8);

        //sll.InsertAfterNode(1, 100);
        //sll.InsertBeforeNode(1, 700);

        //for (int i = 0; i < sll.sll_nodeCount; i++)
        //{
        //    Debug.Log(sll.FindNode(i).sll_Data);
        //}

        dll.AddLast(1);
        dll.AddLast(2);
        dll.AddFirst(4);
        dll.AddLast(3);

        Debug.Log(dll.Head_dll.NextNode.dll_Data +" :"+dll.Tail_dll.dll_Data);

        for (int i = 0; i < dll.dll_nodeCount; i++)
        {
            //Debug.Log(dll.FindNode(i).dll_Data);
        }
    }


}
