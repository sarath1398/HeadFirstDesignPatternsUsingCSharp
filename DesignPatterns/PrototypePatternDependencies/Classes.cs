using static PrototypePatternDependencies.Interfaces;

namespace PrototypePatternDependencies
{
    public class Classes
    {
        public class Ability
        {
            public string Name { get; set; }

            public int HitPoints { get; set; }
        }

        public class WellKnownMonster : IMonster
        {
            public string Name { get; set; }
            public int Health { get; set; }

            public WellKnownMonster(string name, int health)
            {
                Name = name;
                Health = health;
            }

            public WellKnownMonster(IMonster monster)
            {
                var tempMonster = (WellKnownMonster)monster;
                this.Health = tempMonster.Health;
                this.Name = tempMonster.Name;
            }

            public IMonster Clone()
            {
                // Shallow Copy
                return new WellKnownMonster(this);
            }

            public void ShowStats()
            {
                Console.WriteLine($"WellKnownMonster: {Name}, HP: {Health}");
            }
        }

        public class DynamicPlayerGeneratedMonster(string name) : IMonster
        {
            public string CustomName { get; set; } = name;
            public List<Ability> Abilities { get; set; } = [];

            public IMonster Clone()
            {
                // Deep Copy
                var clone = (DynamicPlayerGeneratedMonster)this.MemberwiseClone();
                clone.Abilities = [.. this.Abilities];
                return clone;
            }

            public void ShowStats()
            {
                Console.WriteLine($"DynamicMonster: {CustomName}," +
                    $" Abilities: {string.Join(", ", Abilities.Select(ability => ability.Name 
                    + " with hitpoints - " + ability.HitPoints))}");
            }
        }

        public class MonsterRegistry
        {
            private readonly Dictionary<string,IMonster> _monsters = [];

            public void AddMonsterToRegistry(string key,IMonster monster)
            {
                _monsters[key] = monster;
            }

            public IMonster SpawnRandomMonster()
            {
                var randomNumber = new Random().Next(0, _monsters.Count);
                var keys = _monsters.Keys.ToList();
                var randomMonsterId = keys[randomNumber];
                return _monsters[randomMonsterId].Clone();
            }

            public IMonster GetMonsterByKey(string key)
            {
                IMonster monster;
                _monsters.TryGetValue(key,out monster);
                return monster.Clone();
            }
        }
    }
}
