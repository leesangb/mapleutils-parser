namespace MapleUtils.Parser.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                using var mapleutilsParser = MapleUtilsParser.Create(isHeadless: false);
                var test = mapleutilsParser.GetCharacterAsync("상빈").Result;
                Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(test));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}