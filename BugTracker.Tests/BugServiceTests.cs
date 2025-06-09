using System;
using Xunit;
using BugTracker.Core;

namespace BugTracker.Tests
{
    public class BugServiceTests
    {
        [Fact]
        public void AddBug_ShouldStoreBugInList()
        {
            var service = new BugService();
            var bug = new Bug("Test bug", "Description");

            service.AddBug(bug);
            var allBugs = service.GetAllBugs();

            Assert.Contains(bug, allBugs);
        }

        [Fact]
        public void UpdateStatus_ShouldChangeStatus_WhenValid()
        {
            var service = new BugService();
            var bug = new Bug("Status Bug", "Test transition");
            service.AddBug(bug);

            var success = service.UpdateStatus(bug.Id, BugStatus.InProgress);

            Assert.True(success);
            Assert.Equal(BugStatus.InProgress, bug.Status);
        }

        [Fact]
        public void CannotTransitionFromClosedToOpen()
        {
            var service = new BugService();
            var bug = new Bug("Closed bug", "Already closed");
            service.AddBug(bug);

            service.UpdateStatus(bug.Id, BugStatus.InProgress); 
            service.UpdateStatus(bug.Id, BugStatus.Closed);     

            Assert.Throws<InvalidOperationException>(() =>
            {
                service.UpdateStatus(bug.Id, BugStatus.Open); 
            });
        }


        [Fact]
        public void CannotReassignSameStatus()
        {
            var service = new BugService();
            var bug = new Bug("Repeat Status", "Trying same status");
            service.AddBug(bug);

            Assert.Throws<InvalidOperationException>(() =>
            {
                service.UpdateStatus(bug.Id, BugStatus.Open); 
            });
        }

        [Fact]
        public void CanTransitionFromPendingToClosed()
        {
            var service = new BugService();
            var bug = new Bug("Pending bug", "Test");
            service.AddBug(bug);

            service.UpdateStatus(bug.Id, BugStatus.InProgress);
            service.UpdateStatus(bug.Id, BugStatus.Pending);

            var success = service.UpdateStatus(bug.Id, BugStatus.Closed);

            Assert.True(success);
            Assert.Equal(BugStatus.Closed, bug.Status);
        }

        [Fact]
        public void CannotTransitionFromClosedToPending()
        {
            var service = new BugService();
            var bug = new Bug("Closed bug", "Invalid transition");
            service.AddBug(bug);

            service.UpdateStatus(bug.Id, BugStatus.InProgress);
            service.UpdateStatus(bug.Id, BugStatus.Closed);

            Assert.Throws<InvalidOperationException>(() =>
            {
                service.UpdateStatus(bug.Id, BugStatus.Pending);
            });
        }
    }
}
