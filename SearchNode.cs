using System;

public class SearchNode
{
	public SearchNode(SearchNode parent, int city)
	{
		Parent = parent;
		City = city;
	}

	public SearchNode Parent { get; set; }
	public int City { get; set; }

}
