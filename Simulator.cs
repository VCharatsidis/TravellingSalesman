using System;
using System.Collections.Generic;
using System.Linq;
using Traveling_Salesman;

public class Simulator
{
	public int TotalCities { get; }
	public Simulator(int numberCities)
	{
		TotalCities = numberCities;
	}

	public Dictionary<int, List<int>> BuildCities()
	{
		Random rnd = new Random();

		Dictionary<int, List<int>> cities = new Dictionary<int, List<int>>();
		cities[0] = new List<int>();
		cities[0].Add(1);

		cities[1] = new List<int>();
		cities[1].Add(0);
		
		for (int city = 2; city < TotalCities; city++)
		{
			cities[city] = new List<int>();
			cities[city].Add(city - 1);
			cities[city - 1].Add(city);

			int randomConnection = rnd.Next(city - 1);
			cities[city].Add(randomConnection);
			cities[randomConnection].Add(city);
		}

		return cities;
	}


	public void FindPath(int cityStart, int cityTarget, Dictionary<int, List<int>> cities)
	{
		Queue<SearchNode> toExplore = new Queue<SearchNode>();
		HashSet<SearchNode> explored = new HashSet<SearchNode>(new NodeComparer());

		SearchNode startingNode = new SearchNode(null, cityStart);
		toExplore.Enqueue(startingNode);

		while(toExplore.Count > 0)
		{
			SearchNode currentNode = toExplore.Dequeue();

			if (explored.Contains(currentNode))
			{
				continue;
			}

			Console.WriteLine("investigate city: " + currentNode.City);

			if(cities[currentNode.City].Contains(cityTarget))
			{
				PrintPath(cityStart, cityTarget, currentNode, explored.Count);
			}

			explored.Add(currentNode);

			foreach(int neighb in cities[currentNode.City])
			{
				SearchNode searchNode = new SearchNode(currentNode, neighb);

				if (!explored.Contains(searchNode))
				{
					toExplore.Enqueue(searchNode);
				}
			}
		}

	}

	private void PrintPath(int start, int target, SearchNode endNode, int nodesExplored)
	{
		Console.WriteLine("");
		Console.Write("Path from city " + target + " to " + start + " is: " + target +", ");

		SearchNode node = endNode;

		while(node.Parent != null)
		{
			Console.Write(node.City + ", ");
			node = node.Parent;
		}

		Console.WriteLine(node.City + "");
		Console.WriteLine("Nodes explored: " + nodesExplored);
		Console.ReadLine();
	}

	public void PrintCityNeighbours(Dictionary<int, List<int>> cities)
	{
		int total_neighbs = 0;
		foreach (KeyValuePair<int, List<int>> kvp in cities)
		{
			Console.Write("city: " + kvp.Key + " neigbours: ");

			foreach (int i in kvp.Value)
			{
				total_neighbs++;
				Console.Write(i);
				Console.Write(", ");
			}
			Console.WriteLine("");
		}

		Console.WriteLine("total neighbs: " + total_neighbs);
		Console.WriteLine("");
	}
}
