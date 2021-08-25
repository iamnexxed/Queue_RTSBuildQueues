using UnityEngine;


class Queue 
{
	SList data;

	public Queue()
    {
		data = new SList();
    }
	public void enqueue(GameObject value)
	{
		data.Push_back(value);
	}

	public void dequeue()
	{
		data.Pop_front();
	}

	public GameObject front()
	{
		return data.Front();
	}

	public bool empty()
	{
		return data.Empty();
	}

	public uint size() 
	{
		return data.Size();
	}

	public void clear()
	{
		data.Clear();
	}
};


