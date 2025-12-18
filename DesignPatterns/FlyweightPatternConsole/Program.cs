using static FlyweightPatternDependencies.Classes;

namespace FlyweightPatternConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] treeData =
            [
                [10, 20, 5],
                [50, 60, 1],
                [100, 100, 12],
                [120, 140, 8]
            ];

            TreeManager treeManager = new();

            foreach (var tree in treeData)
            {
                treeManager.Add(tree[0], tree[1], tree[2]);
            }

            // Render all trees using the single Flyweight instance
            treeManager.DisplayTrees();
        }
    }
}
