using static PrototypePatternDependencies.Classes;
using static PrototypePatternDependencies.Interfaces;

namespace MonsterMaker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MonsterRegistry registry = new();

            WellKnownMonster birdMonster = new("Zapdos", 175);

            DynamicPlayerGeneratedMonster bossMonster = new("Boss Raichu");
            bossMonster.Abilities.Add(new Ability() { Name = "Thunderbolt", HitPoints = 40 });
            bossMonster.Abilities.Add(new Ability() { Name = "Thunder Punch", HitPoints = 50 });
            bossMonster.Abilities.Add(new Ability() { Name = "Slam", HitPoints = 20 });

            registry.AddMonsterToRegistry("Zapdos", birdMonster);
            registry.AddMonsterToRegistry("Boss Raichu", bossMonster);

            IMonster m1 = registry.GetMonsterByKey("Zapdos");
            m1.ShowStats();
            bossMonster.ShowStats();

            // Deep Copy of DynamicPlayerGeneratedMonster class
            DynamicPlayerGeneratedMonster m2 = 
                (DynamicPlayerGeneratedMonster)registry.GetMonsterByKey("Boss Raichu");
            m2.CustomName = "Mega Evolved Boss Raichu";
            m2.Abilities.Add(new Ability() { Name = "Giga Shock", HitPoints = 80 }); 
            
            m2.ShowStats();
            bossMonster.ShowStats();
        }
    }
}
