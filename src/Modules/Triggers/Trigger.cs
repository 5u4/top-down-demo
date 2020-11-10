using System.Collections.Generic;
using System.Linq;
using Godot;
using TopDownDemo.Modules.Triggers.Conditions;
using TopDownDemo.Modules.Triggers.Executors;

namespace TopDownDemo.Modules.Triggers
{
    public class Trigger : Node2D
    {
        [Export] public string HotKey;

        /**
         * Passes all conditions
         */
        public bool CanTrigger()
        {
            return GetConditions().All(condition => condition.Ok());
        }

        public override void _Process(float delta)
        {
            if (!Input.IsActionPressed(HotKey) || !CanTrigger()) return;
            foreach (var condition in GetConditions()) condition.Trigger();
            foreach (var executor in GetExecutors()) executor.Execute();
        }

        public IEnumerable<Executor> GetExecutors()
        {
            return GetChildren().Cast<Node2D>()
                .Where(executor => executor is Executor).Cast<Executor>();
        }

        public IEnumerable<Condition> GetConditions()
        {
            return GetChildren().Cast<Node2D>()
                .Where(condition => condition is Condition).Cast<Condition>();
        }
    }
}
