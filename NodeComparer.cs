using System;
using System.Collections.Generic;


class NodeComparer : IEqualityComparer<SearchNode>
{
	public bool Equals(SearchNode x, SearchNode y)
	{
		return x.City == y.City;
	}

	public int GetHashCode(SearchNode node)
	{
		return node.City;
	}
}

