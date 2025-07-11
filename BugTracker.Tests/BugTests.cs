﻿using BugTracker.Core;

using Xunit;

namespace BugTracker.Tests
{
    public class BugTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_ThrowsArgumentException_WhenTitleIsInvalid(string invalidTitle)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Bug(invalidTitle, "Some description"));
        }

        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var bug = new Bug("Login fails", "Steps to reproduce the issue");

            // Assert
            Assert.Equal("Login fails", bug.Title);
            Assert.Equal("Steps to reproduce the issue", bug.Description);
            Assert.Equal(BugStatus.Open, bug.Status);
        }

        [Fact]
        public void UpdateStatus_ChangesStatusCorrectly()
        {
            // Arrange
            var bug = new Bug("Issue", "Details");

            // Act
            bug.UpdateStatus(BugStatus.InProgress);

            // Assert
            Assert.Equal(BugStatus.InProgress, bug.Status);
        }

        [Fact]
        public void UpdateStatus_DoesNotChangeToSameStatus()
        {
            var bug = new Bug("Duplicate Status", "Trying to set same status");

            Assert.Throws<InvalidOperationException>(() =>
            {
                bug.UpdateStatus(BugStatus.Open); // Already Open
            });
        }

        [Fact]
        public void UpdateStatus_DoesNotAllowTransitionFromClosedToPending()
        {
            var bug = new Bug("Closed Bug", "Trying invalid transition");
            bug.UpdateStatus(BugStatus.InProgress);
            bug.UpdateStatus(BugStatus.Closed);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bug.UpdateStatus(BugStatus.Pending); // Invalid
            });
        }

        [Fact]
        public void CanAddAttachmentUrl()
        {
            var bug = new Bug("Attachment Test", "Testing image URL property");
            bug.AttachmentUrl = "http://example.com/image.png";
            Assert.Equal("http://example.com/image.png", bug.AttachmentUrl);
        }

        [Fact]
[Fact]
public void Bug_EstimatedFixTime_CanBeSetAndRetrieved()
{
    var bug = new Bug("Slow loading", "Page takes too long");
    bug.EstimatedFixTimeHours = 5;
    Assert.Equal(5, bug.EstimatedFixTimeHours);
}

[Fact]
public void Bug_Priority_CanBeSetToHigh()
{
    var bug = new Bug("Critical Bug", "This bug breaks the app.");
    bug.Priority = PriorityLevel.High;

    Assert.Equal(PriorityLevel.High, bug.Priority);
}

        }

    }
}
