using Xunit;
using To_Doodles;
using System.Linq;

namespace ToDoodles.Tests
{
    public class TaskTests
    {
        [Fact]
        public void ToggleComplete_ShouldMarkTaskAsComplete_AndBack()
        {
            // Arrange
            var fakeManager = new TaskManagerStub();
            var task = new To_Doodles.Task { Manager = fakeManager };
            fakeManager.AddActiveTask(task);

            // Act - toggle to complete
            task.ToggleComplete();

            // Assert - check if task is complete
            Assert.True(task.IsComplete);
            Assert.True(task.WasCompleted);
            Assert.Contains(fakeManager.CompleteTasks, t => t == task);
            Assert.DoesNotContain(fakeManager.ActiveTasks, t => t == task);

            // Act - toggle back to active
            task.ToggleComplete();

            // Assert - check if task is active again
            Assert.False(task.IsComplete);
            Assert.Contains(fakeManager.ActiveTasks, t => t == task);
            Assert.DoesNotContain(fakeManager.CompleteTasks, t => t == task);
        }
        
        [Fact]
        public void ToggleComplete_ShouldCallProcessTaskCompletionOnlyOnce()
        {
            // Arrange
            var fakeManager = new TaskManagerSpy();
            var task = new To_Doodles.Task { Manager = fakeManager };
            fakeManager.AddActiveTask(task);

            // Act - toggle to complete first time
            task.ToggleComplete();

            // Assert - ProcessTaskCompletion called once
            Assert.Equal(1, fakeManager.ProcessTaskCompletionCallCount);

            // Act - toggle back to active and complete again
            task.ToggleComplete();
            task.ToggleComplete();

            // Assert - ProcessTaskCompletion still only called once
            Assert.Equal(1, fakeManager.ProcessTaskCompletionCallCount);
        }
    }
}