// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Figgle;
var client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("http://ip-api.com/json/");
if (response.IsSuccessStatusCode)
{
    string responseContent = await response.Content.ReadAsStringAsync();
    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(FiggleFonts.Computer.Render(jsonResponse["query"].ToString()));
    Console.ResetColor();
    Console.WriteLine("          IP: " + jsonResponse["query"]);
    Console.WriteLine("     Country: " + jsonResponse["country"]);
    Console.WriteLine("        City: " + jsonResponse["city"]);
    Console.WriteLine("Country Code: " + jsonResponse["countryCode"]);
    Console.WriteLine("         ISP: " + jsonResponse["isp"]);
    Console.WriteLine("    Latitude: " + jsonResponse["lat"]);
    Console.WriteLine("   Longitude: " + jsonResponse["lon"]);
    Console.WriteLine("Organization: " + jsonResponse["org"]);
    Console.WriteLine("         ASN: " + jsonResponse["as"]);
    Environment.Exit(0);
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
    Console.ResetColor();
    Environment.Exit(1);
}