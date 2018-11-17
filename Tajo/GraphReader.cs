﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ASD.Graphs;


namespace Tajo
{
    public class GraphReader
    {

        public static Graph ReadCSV(string path)
        {
            using (var reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var graph = new AdjacencyMatrixGraph(false, values.Length);
                int i = 0;
                int j = 0;
                foreach (var x in values)
                {
                    if (int.Parse(x) == 1)
                        graph.AddEdge(i, j);
                    i++;
                }
                while (!reader.EndOfStream)
                {
                    i = 0;
                    j++;
                    line = reader.ReadLine();
                    values = line.Split(',');
                    foreach (var x in values)
                    {
                        if (int.Parse(x) == 1)
                            graph.AddEdge(i, j);
                        i++;
                    }
                }
                return graph;
            }
        }
    }
}
