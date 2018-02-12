using System;
using System.Collections.Generic;
using System.Text;

namespace Commons
{
   public interface ICommit
    {
         List<string> CommitClient();
         void CommitServer();
    }
}
