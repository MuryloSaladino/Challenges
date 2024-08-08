using System.IO;
using System.Linq;

public static class CovidDataAnalyis
{
    public static ulong VacinatedDeaths { get; private set; } = 0;
    public static ulong NonVacinatedDeaths { get; private set; } = 0;

    public record Result(string Title, double Percentage) {}


    public static void CalculateNumberOfDeaths()
    {
        VacinatedDeaths = 0;
        NonVacinatedDeaths = 0;

        using var reader = new StreamReader("./covid/data.csv");
        var firstLine = reader.ReadLine().Split(";");

        int deathColumn = firstLine.CustomIndexOf(s => s == "\"EVOLUCAO\"");
        int sickTypeColumn = firstLine.CustomIndexOf(s => s == "\"CLASSI_FIN\"");
        int vacineColumn = firstLine.CustomIndexOf(s => s == "\"VACINA_COV\"");
        
        var query = reader
            .ReadToEnd()
            .Split('\n')
            .Where(line => line.Length > 10)
            .Select(line => line.Split(";"))
            .Where(line => {
                var str = line[vacineColumn];
                return str == "1" || str == "2";
            })
            .Where(line => line[sickTypeColumn] == "5")
            .GroupBy(line => line[vacineColumn])
            .Select(group => {
                double dead = group.Where(line => line[deathColumn] == "2").Count();
                return new Result(group.Key, dead / group.Count());
            });

        foreach(var i in query)
        {
            Console.WriteLine($"{i.Title} => {i.Percentage}");
        }
    }
}