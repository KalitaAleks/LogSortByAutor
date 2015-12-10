using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSortByAutor
    {
    public static class CommitComparer
        {
        public static int CompareByAutor(Commit leftCommit, Commit rightCommit)
            {
            if (rightCommit == null && leftCommit == null)
                {
                return 0;
                }
            if (leftCommit == null)
                {
                return -1;
                }
            if (rightCommit == null)
                {
                return 1;
                }

            return leftCommit.Autor.CompareTo(rightCommit.Autor);
            }
        }
    }
