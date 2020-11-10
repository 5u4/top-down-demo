using Godot;

namespace TopDownDemo.Creatures
{
    public class Creature : Node2D
    {
        [Export] public Faction Faction = Faction.None;

        public virtual void OnDamaged(int amount) {}
    }
}
