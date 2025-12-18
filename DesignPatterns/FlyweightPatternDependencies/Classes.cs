namespace FlyweightPatternDependencies
{
    public class Classes
    {
        public class Tree
        {
            public static void Display(int age, int xCoord, int yCoord)
            {
                Console.WriteLine($"Displaying a tree of Age {age} at position ({xCoord},{yCoord})");
            }
        }

        public class TreeManager
        {
            private Tree _tree;
            private int _counter = 0;

            // The cache for storing X-Axis Coordinates, Y-Axis Coordinates and Tree's Age
            
            // It is assumed that the X-Axis and Y-Axis coordinates are unique since multiple trees
            // cannot be rendered in same page. 
            private readonly Dictionary<int, List<int>> _cache = [];

            public void Add(int xCoord, int yCoord, int age)
            {
                if (_cache.TryAdd(_counter++, [xCoord, yCoord, age]) == false)
                {
                    throw new ArgumentException(); // TODO: ideal approach is to create a lock object to avoid concurrent handling of objects
                }
            }

            public void DisplayTrees()
            {
                foreach (var key in _cache.Keys)
                {
                    List<int> value = _cache[key];
                    (int xCoord, int yCoord, int age) = (value[0], value[1], value[2]);
                    Tree.Display(age, xCoord, yCoord);
                }
            }
        }
    }
}
