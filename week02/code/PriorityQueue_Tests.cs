using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue elements with differing priorities: ItemA (Pri: 2), ItemB (Pri: 5), ItemC (Pri: 1).
    // Expected Result: ItemB (5) is dequeued first because it has the highest priority.
    // Defect(s) Found: The loop range limit (_queue.Count - 1) skipped checking the item at the back, and the item was never removed from the list after dequeuing. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 2);
        priorityQueue.Enqueue("ItemB", 5);
        priorityQueue.Enqueue("ItemC", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items sharing the same maximum priority: ItemA (Pri: 4), ItemB (Pri: 2), ItemC (Pri: 4).
    // Expected Result: ItemA should be returned first because it arrived closest to the front (FIFO tracking for ties).
    // Defect(s) Found: The search logic incorrectly used `>=` instead of `>`, causing the queue to return the *last* tied item seen (ItemC) instead of the first (ItemA). 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 4);
        priorityQueue.Enqueue("ItemB", 2);
        priorityQueue.Enqueue("ItemC", 4);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemA", result);
    }

    [TestMethod]
    // Scenario: Enqueue an item that has the highest priority at the absolute end of the line: ItemA (Pri: 2), ItemB (Pri: 6).
    // Expected Result: ItemB is cleanly returned.
    // Defect(s) Found: Due to loop execution boundaries failing to reach the final index, ItemB was skipped entirely and ItemA was incorrectly returned.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 2);
        priorityQueue.Enqueue("ItemB", 6);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("ItemB", result);
    }

    [TestMethod]
    // Scenario: Attempt to pop/dequeue an item from a freshly initialized, completely empty queue.
    // Expected Result: Throws an InvalidOperationException containing the exact message: "The queue is empty."
    // Defect(s) Found: None. The exception throwing guard block functions correctly.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("An exception should have been thrown for an empty queue.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

}