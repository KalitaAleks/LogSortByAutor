using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSortByAutor
    {
    class Program
        {
        static void Main(string[] args)
            {
            List<Commit> Commits = new List<Commit>();
            string fileFullPath = Path.GetFullPath(@"log.txt");

            if (!File.Exists(fileFullPath))
                {
                throw new FileNotFoundException();
                }
            string line;
            using (StreamReader file = new StreamReader(fileFullPath))
                {
                for (int i = 0; i <= fileFullPath.Length; i++)
                    {
                    line = file.ReadLine();
                    if (line.StartsWith("commit"))
                        {
                         Commit commit = new Commit();
                        Commits.Add(commit);
                        }

                        if (line.StartsWith("Author:"))
                            {
                            Commits[i-1].Autor = line;
                            }
                        if (line.StartsWith("Date:"))
                            {
                            Commits[i-2].Date = line;
                            }
                        if (line.StartsWith("commit") != true && line.StartsWith("Author:") != true && line.StartsWith("Date:") != true)
                            {
                            Commits[i-3].Massage = line;
                            }
                        }
                    }
            Commits.Sort(CommitComparer.CompareByAutor);
            string autor = Commits[1].Autor;
            Console.WriteLine(autor);
            foreach (Commit commit in Commits)
                {
                if (commit.Autor == autor)
                    {
                    Console.WriteLine(commit.Date);
                    Console.WriteLine(commit.Massage);
                    }
                if (commit.Autor != autor) 
                    {
                    autor = commit.Autor;
                    Console.WriteLine(autor);
                    }
                }

            Console.ReadKey();
            }
        }
    }
