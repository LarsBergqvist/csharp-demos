using System;

namespace DelegatesDemo
{
    public class WorkPerformedEventArgs: System.EventArgs
    {
        public int Progress { get; set; }
    }

//    public delegate void WorkPerformedDelegate(int progress);

    public class Worker
    {
//        public event WorkPerformedDelegate WorkPerformed;

        // Don't need delegate when using EventHandler<T>
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        public void DoWork(int total)
        {
            for (int i=0; i < total; i++)
            {
                OnWorkPerformed(i+1);
            }
        }

        // Protected virtual so that it can be overridden by subclasses
        protected virtual void OnWorkPerformed(int progress)
        {
            if (this.WorkPerformed != null)
            {
                var args = new WorkPerformedEventArgs() {
                    Progress = progress
                };
                WorkPerformed(this, args);
            }
        }

    }
}
