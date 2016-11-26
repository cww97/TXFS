using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_Analyze.Analyze;

namespace Console_Analyze
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var text = Console.ReadLine();
                var task = AnalyzeSocket.query(text);
                task.Wait();
                var result = task.Result;

                var type = result.topScoringIntent.intent;
                Console.WriteLine(type);
                if (type != "nonsense" && type != "dispatch" && type != "dispatch.interrupt"
                    && !type.StartsWith("greeting"))
                {
                    int count = 0;
                    if (filter_data(result.entities, "builtin.datetime")) ++count;
                    if (filter_data(result.entities, "sp")) ++count;
                    if (filter_data(result.entities, "v")) ++count;
                    if (filter_data(result.entities, "builtin.number")) ++count;
                    if (filter_data(result.entities, "builtin.money")) ++count;
                    if (filter_data(result.entities, "np")) ++count;
                    Console.Write("\n\n");
                }
            }
            
        }

        static bool filter_data(entity_class[] entities, string type)
        {
            int count = 0;
            foreach (var v in entities)
            {
                if (v.type.StartsWith(type))
                {
                    Console.Write(v.entity);
                    ++count;
                }
            }
            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
