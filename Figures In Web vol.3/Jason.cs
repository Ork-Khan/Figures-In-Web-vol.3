using Newtonsoft.Json;
using Serialized_Shapes_2._0.Figures;

namespace Figures_In_Web_vol._3
{
    static class Jason
    {
        public static void Jasonize(string Path, LinkedList<Figure> figures)
        {
            using(TextWriter writer = new StreamWriter(Path))
            {
                string Serialized = JsonConvert.SerializeObject(figures, (new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented }));
                writer.WriteLine(Serialized);
            }
        }
        public static void DeJasonize(string Path, ref LinkedList<Figure> figures)
        {
            using(TextReader reader = new StreamReader(Path))
            {
                Newtonsoft.Json.JsonSerializer jsonserializer = Newtonsoft.Json.JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented });
                figures = (LinkedList<Figure>)jsonserializer.Deserialize(reader, typeof(LinkedList<Figure>));
            }
        }
    }
}
