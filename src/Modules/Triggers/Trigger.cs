using System.Linq;
using Godot;
using TopDownDemo.Modules.Triggers.Conditions;
using TopDownDemo.Modules.Triggers.Executors;

namespace TopDownDemo.Modules.Triggers
{
    public class Trigger : Node2D
    {
        [Export] public Condition[] Conditions = {};
        [Export] public Executor[] Executors = {};
        [Export] public string HotKey;

        /**
         * Passes all conditions
         */
        public bool CanTrigger()
        {
            return Conditions.All(condition => condition.Ok());
        }

        public override void _Process(float delta)
        {
            if (!Input.IsActionPressed(HotKey) || !CanTrigger()) return;
            foreach (var executor in Executors) executor.Execute();
        }
    }
}
