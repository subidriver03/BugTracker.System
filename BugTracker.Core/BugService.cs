
using System.Collections.Generic;
using System.Linq;

namespace BugTracker.Core
{
    public class BugService
    {
        private readonly List<Bug> _bugs = new();

        public void AddBug(Bug bug)
        {
            _bugs.Add(bug);
        }

        public List<Bug> GetAllBugs()
        {
            return _bugs.ToList();
        }

        public bool UpdateStatus(int id, BugStatus newStatus)
        {
            var bug = _bugs.FirstOrDefault(b => b.Id == id);
            if (bug == null) return false;

            // TODO: Enforce transition rules here (Open → InProgress, etc.)
            bug.UpdateStatus(newStatus);
            return true;
        }
    }
}
