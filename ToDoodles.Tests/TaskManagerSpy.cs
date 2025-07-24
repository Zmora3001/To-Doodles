using To_Doodles;

namespace ToDoodles.Tests
{
    public class TaskManagerSpy : TaskManagerStub
    {
        public int ProcessTaskCompletionCallCount { get; private set; }

        public override void ProcessTaskCompletion(Task task)
        {
            ProcessTaskCompletionCallCount++;
        }
    }
}