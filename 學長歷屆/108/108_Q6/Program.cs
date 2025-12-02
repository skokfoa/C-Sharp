using System;
using System.Collections.Generic;
using System.Linq;

namespace _108_Q6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("鍵入「輸入小圓盤」的數目及其名稱：");

            List<Plate> plates = new List<Plate>();
            List<Relation> relations = new List<Relation>();

            string[] inputs = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var input in inputs.Skip(1))
                plates.Add(new Plate
                {
                    name = input,
                    type = PlateType.Input,
                });

            Console.WriteLine("鍵入「內部小圓盤」的數目及其名稱：");

            inputs = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var input in inputs.Skip(1))
                plates.Add(new Plate
                {
                    name = input,
                    type = PlateType.Input,
                });

            Console.WriteLine("鍵入「輸出小圓盤」的數目及其名稱：");

            inputs = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var input in inputs.Skip(1))
                plates.Add(new Plate
                {
                    name = input,
                    type = PlateType.Input,
                });


            while(true)
            {
                Console.WriteLine("鍵入「2-1轉移棒」的名稱及小圓盤名稱：");

                inputs = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                relations.Add(new Relation
                {
                    name = inputs[0],
                    parents = inputs.Skip(1).Take(2).Select(x => plates.Find(p => p.name == x)).ToArray(),
                    child = plates.Find(x => x.name == inputs[3])
                });

                Console.Write("Continue?(1/0)：");

                if (Console.ReadLine().Trim() == "0")
                    break;
            }

            while (true)
            {
                Console.WriteLine("鍵入「1-1轉移棒」的名稱及小圓盤名稱：");

                inputs = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                relations.Add(new Relation
                {
                    name = inputs[0],
                    parents = inputs.Skip(1).Take(1).Select(x => plates.Find(p => p.name == x)).ToArray(),
                    child = plates.Find(x => x.name == inputs[2])
                });

                Console.Write("Continue?(1/0)：");

                if (Console.ReadLine().Trim() == "0")
                    break;
            }

            Console.WriteLine("轉移棒與小圓盤的關係:");

            foreach(var relation in relations)
            {
                var parents = string.Join(" ", relation.parents.Select(x => x.name));

                Console.Write($"{relation.name}: {parents} {relation.child.name} ");
            }

            Console.WriteLine();
            Console.WriteLine("小圓盤與轉移棒的關係:");

            foreach (var plate in plates)
            {
                string all = string.Join(" ", relations.FindAll(x => x.parents.Contains(plate) || x.child == plate).Select(x => x.name));

                Console.Write($"{plate.name}: {all} ");
            }

            Console.WriteLine();

            while (true)
            {
                Console.Write("鍵入將放權重的小圓盤名稱:");

                string input = Console.ReadLine().Trim();

                Plate plate = plates.Find(x => x.name == input);

                plate.token = true;

                string status = string.Join(" ", plates.Select(x => $"{x.name}:{(x.token ? 1 : 0)}"));

                Console.WriteLine($"查詢各個小圓盤權杖的情況: {status}");
                Console.WriteLine($"執行轉移棒.");

                while (relations.Exists(x => x.parents.All(p => p.token) && !x.child.token))
                {
                    var relation = relations.Find(x => x.parents.All(p => p.token) && !x.child.token);

                    foreach (var parent in relation.parents)
                        parent.token = false;

                    relation.child.token = true;
                }

                status = string.Join(" ", plates.Select(x => $"{x.name}:{(x.token ? 1 : 0)}"));

                Console.WriteLine($"查詢各個小圓盤權杖的情況: {status}");
                Console.Write("Continue?(1/0):");

                if (Console.ReadLine().Trim() == "0")
                    break;
            }

            Console.ReadLine();
        }
    }

    class Relation
    {
        public string name;
        public Plate child;
        public Plate[] parents;
    }

    class Plate
    {
        public PlateType type;
        public string name;
        public bool token = false;
    }

    enum PlateType
    {
        Input,
        Internal,
        Output,
    }
}
