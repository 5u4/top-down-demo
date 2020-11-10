using Godot;
using TopDownDemo.Modules.Weapons.Spawner;

namespace TopDownDemo.Modules.Triggers.Executors.SpawnExecutor
{
    public class SpawnExecutor : Executor
    {
        [Export] public NodePath SpawnerPath = "../../../Spawner";

        public Spawner Spawner;

        public override void _Ready()
        {
            Spawner = GetNode<Spawner>(SpawnerPath);
        }

        public override void Execute()
        {
            Spawner.Spawn();
        }
    }
}
