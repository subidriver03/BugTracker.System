namespace BugTracker.Core
{
    public class Bug
    {
        private static int _idSeed = 1;

        public int Id { get; }
        public string Title { get; }
        public string Description { get; set; }
        public BugStatus Status { get; private set; }
        public string AssignedToDeveloper { get; set; }
        public string? AttachmentUrl { get; set; }

        /// <summary>
        /// Estimated time in hours to fix the bug (optional).
        /// </summary>
        public int? EstimatedFixTimeHours { get; set; }

        public Bug(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Bug title cannot be empty or whitespace.", nameof(title));
            }

            Title = title;
            Description = description;
            Status = BugStatus.Open;
            Id = _idSeed++;
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            if (Status == newStatus)
                throw new InvalidOperationException("Bug is already in the requested status.");

            if (Status == BugStatus.Closed)
                throw new InvalidOperationException("Cannot change status once it is Closed.");

            if (Status == BugStatus.Open && newStatus != BugStatus.InProgress)
                throw new InvalidOperationException("Open bugs can only move to InProgress.");

            if (Status == BugStatus.InProgress && newStatus != BugStatus.Pending && newStatus != BugStatus.Closed)
                throw new InvalidOperationException("InProgress bugs can only move to Pending or Closed.");

            if (Status == BugStatus.Pending && newStatus != BugStatus.InProgress && newStatus != BugStatus.Closed)
                throw new InvalidOperationException("Pending bugs can only move to InProgress or Closed.");

            Status = newStatus;
        }
    }
}
