using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neo4j.Driver.V1;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "password")))
            using (var session = driver.Session())
            {

                var result = session.Run("MATCH (movies:Movie) WHERE movies.title =~ '.*The.*' RETURN movies");
                //var result = session.Run("MATCH (act:Person) -[:ACTED_IN]->(movies:Movie) WHERE act.name = 'Tom Cruise' RETURN movies");
                //var result = session.Run("MATCH (act:Person) -[:ACTED_IN]->(movies:Movie) WHERE act.born < 1930 RETURN movies");
                //var result = session.Run("MATCH (act:Person) -[:DIRECTED]->(movies:Movie) WHERE act.name = 'Mike Nichols' Return movies");
                   


                foreach (var node in result)
                {
                    var iNode = node["movies"].As<INode>();

                    Console.WriteLine($"Title: {iNode.Properties["title"].As<String>()}");
                    Console.WriteLine($"Released: {iNode.Properties["released"].As<String>()}\n\n");

                }
            }
            Console.ReadLine();
        }
    }
}
