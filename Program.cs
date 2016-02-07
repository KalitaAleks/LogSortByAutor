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
                while (file.EndOfStream != true)
                    {
                    line = file.ReadLine();

                    if (line.StartsWith("commit") == true)
                        {
                        Commit commit = new Commit();
                        Commits.Add(commit);
                        line = file.ReadLine();
                        if (line.StartsWith("commit") != true)
                            {
                            if (line.StartsWith("Author:"))
                                {
                                commit.Autor = line;
                                line = file.ReadLine();
                                }

                            if (line == null)
                                {
                                line = file.ReadLine();
                                }
                            while (line.StartsWith("Author:") != true && line.StartsWith("commit") != true)
                                {
                                commit.Massage = commit.Massage + line;
                                line = file.ReadLine();
                                }

                            }

                        }
                    }
                }

            Commits.Sort(CommitComparer.CompareByAutor);
            string autor = Commits[0].Autor;
            Console.WriteLine(autor);
            foreach (Commit commit in Commits)
                {
                if (commit.Autor == autor)
                    {
                    Console.WriteLine(commit.Massage);
                    }
                if (commit.Autor != autor) 
                    {
                    autor = commit.Autor;
                    Console.WriteLine(autor);
                    Console.WriteLine(commit.Massage);
                    }
                }

            Console.ReadKey();
            }
        }
    }
