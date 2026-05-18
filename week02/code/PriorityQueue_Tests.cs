using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The Dequeue function shall remove the item with the highest priority and return its value.
    //create a queue qith the following priorities and values: (A, 1), (B, 2), (C, 3). Dequeue once and check the value returned and the state of the queue after.
    // Expected Result: returned value : C. State of queue a,1 abd b,2 
    // Defect(s) Found: the remove from the queue function was not included in the code, and the - 1 was impeding the loop to use the last value in the queue (because index starts at 0, not 1)
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        // Enqueue{} expectedresult = "C" removed, priority A1, priority B2
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("[A (Pri:1), B (Pri:2)]", priorityQueue.ToString());



    }

    [TestMethod]
    // Scenario: if more than one item has the highest priority, the one closes to the front needs to be removed
    //create a queue with priorities like this: (A, 1), (B, 2), (C, 3), (D, 3). Dequeue once and check the value returned and the state of the queue after.
    // Expected Result: 
        // - Returned value: "C"
        // - Remaining queue: A(1), B(2), D(3)
    // Defect(s) Found: The comparison operator used >= instead of >,  causing the last highest-priority item to be removed instead of the first one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("[A (Pri:1), B (Pri:2), D (Pri:3)]", priorityQueue.ToString());

        // Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result:
    // - An InvalidOperationException is thrown
    // - Exception message is "The queue is empty."
    public void TestEmptyPriorityQueue()
    {
        var priorityQueue = new PriorityQueue();
        // priorityQueue.Enqueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}