using UnityEngine;

public class SList
{
	// Singly Linked List node
	public class Node
	{
		public GameObject gameObject;
		public Node next;     // next node

		public Node(GameObject newObject)
		{
			gameObject = newObject;
			next = null;
		}

	};

	// pointers to first and last nodes in the list
	Node head, tail;
	uint sz = 0;


	// default constructor
	public SList()
	{
		head = null;
		tail = null;
		sz = 0;
	}

	// destructor
	~SList()
	{
		Clear();
	}

	// remove all nodes
	public void Clear()
	{
		// remove a node until empty
		while (!Empty())
			Pop_front();
	}

	// check for empty list
	public bool Empty()
	{
		return sz == 0;
	}

	// return number of members
	public uint Size()
	{
		return sz;
	}

	// return reference to first value in list
	// precondition: list is not empty
	public GameObject Front()
	{
		return head.gameObject;
	}


	// return reference to last value in list
	// precondition: list is not empty
	public GameObject Back()
	{
		return tail.gameObject;
	}

	// insert a value at the beginning of the list
	public void Push_front(GameObject newObject)
	{
		// create new node with value
		Node new_node = new Node(newObject);

		if (Empty())
		{
			// if the list is empty, new node becomes both head and tail
			head = tail = new_node;
		}
		else
		{
			// if the list is not empty, insert new node before head
			new_node.next = head;
			head = new_node;
		}

		++sz;
	}

	// insert a value at the end of the list
	public void Push_back(GameObject newObject)
	{
		// create new node with value
		Node new_node = new Node(newObject);

		if (Empty())
		{
			// if the list is empty, new node becomes both head and tail
			head = tail = new_node;
		}
		else
		{
			// if the list is not empty, insert new node after tail
			tail.next = new_node;
			tail = new_node;
		}

		++sz;
	}

	// remove first element from the list
	// precondition: list is not empty
	public void Pop_front()
	{
		// save pointer to old head
		if (head == tail)
			// if list contained only one element, list is now empty
			head = tail = null;
		else
			// otherwise, reposition head pointer to next element in list
			head = head.next;

		// blow away the old head node
		/*old_head = null;*/

		--sz;
	}

	// remove last element from the list
	// precondition: list is not empty
	public void Pop_back()
	{
		// save old list tail
		Node old_tail = tail;

		if (head == tail)
		{
			// if list contained only one element, list is now empty
			head = tail = null;
		}
		else
		{
			// find new tail by starting at head
			tail = head;
			while (tail.next != old_tail)
				tail = tail.next;
			// the new tail is the node before old tail
			tail.next = null;
		}

		// blow away old tail node
		/*old_tail = null;*/

		--sz;
	}

	// Iterator class -- represents a position in the list.
	// Used to gain access to individual elements, as well as
	// insert, find, and erase elements

	public class Iterator
	{
		// the iterator holds a pointer to the "current" list node
		public Node node;

		// default constructor: iterator not valid until initialized
		public Iterator()
		{
			node = null;
		}

		// equality operator (==)
		// checks whether both iterators represent the same position
		public static bool operator ==(Iterator lhs, Iterator rhs)
		{
			return lhs.node == rhs.node;
		}

		// inequality operator (!=)
		// checks whether iterators represent different positions
		public static bool operator !=(Iterator lhs, Iterator rhs)
		{

			return lhs.node != rhs.node;
		}

		// increment operator
		// advances to next node and returns itself
		public static Iterator operator ++(Iterator it)
		{
			if (it.node.next != null)
			{
				it.node = it.node.next;
				return it;
			}
			return null;
		}

		#region To Suppress Warnings
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return base.ToString();
		}
		#endregion
	}

	// find a value in the list
	// returns: a valid iterator if found, end() if not found
	public Node FindNode(GameObject value)
	{
		for (Node node = head; node != null; node = node.next)
			if (node.gameObject == value)
				return node;
		return null;
	}

	public Iterator Begin()
	{
		Iterator newIt = new Iterator();
		newIt.node = head;
		return newIt;
	}

	public Iterator End()
	{
		return null;
	}

	// erase the list element at pos
	// precondition: pos is a valid iterator
	// returns: an iterator at the element immediately after pos
	public Iterator Erase(Iterator pos)
	{
		Node target = pos.node;  // save target to be erased

		if (pos.node != tail)
		{
			++pos;  // advance iterator
		}


		if (target == head)
			Pop_front();
		else if (target == tail)
			Pop_back();
		else
		{
			// find the node before target
			Node tmp = head;
			while (tmp.next != target)
				tmp = tmp.next;
			// unlink target node
			tmp.next = target.next;
			// delete target node

			--sz;
		}

		return pos; // return advanced iterator
	}

	Iterator insert(Iterator pos, GameObject value)
	{
		Iterator it = new Iterator();
		if (pos == Begin())
		{
			// insert new node before head
			Push_front(value);
			it.node = head;
			return it;
		}
		else if (pos == End())
		{
			Push_back(value);
			it.node = tail;
			return it;
		}
		else
		{
			// find the node before pos
			Node tmp = head;
			while (tmp.next != pos.node)
				tmp = tmp.next;

			// create new node to be inserted
			Node new_node = new Node(value);

			// insert new_node between tmp and pos
			tmp.next = new_node;
			new_node.next = pos.node;

			++sz;
			it.node = new_node;
			return it;
		}
	}
}
