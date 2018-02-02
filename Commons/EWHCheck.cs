using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Commons
{
    public static class EWHCheck
    {
        public static EventWaitHandle OpenorCreate(bool initialState, EventResetMode mode, string name)
        {
            EventWaitHandle ewh = null;
            try
            {
                ewh = EventWaitHandle.OpenExisting(name);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                //Handle does not exist, create it.
                ewh = new EventWaitHandle(initialState, mode, name);
            }
            return ewh;
        }
        public static EventWaitHandle OpenOrWait(string name)
        {
            EventWaitHandle ewh = null;
            while (null == ewh)
            {
                try
                {
                    ewh = EventWaitHandle.OpenExisting(name);
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    Thread.Sleep(50);
                }
            }
            return ewh;
        }
    }
}
