using ConsoleApp1;
using ConsumoDeApi;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Nodes;


bool runProgram = true;

while (runProgram)
{
     try
    {
        
        Console.WriteLine("What you wish?");
        Console.WriteLine("Press 1 for a random advice.");
        Console.WriteLine("Press 2 for you write a word and receive a advice.");
        Console.WriteLine("Press other number for finish program");

        string option = Console.ReadLine();

        if (option == "1")
        {
            RandomAdviceAsync();
            Thread.Sleep(3000);
        }
        else if (option == "2")
        {
            AdviceWordAsync();
            Thread.Sleep(3000);
        }
        else
        {
            runProgram = false;
        }
    }
    catch(Exception ex)
    {
        throw new Exception(ex.Message);
    }
}

static async Task RandomAdviceAsync()
{
    try
    {
        string url = "https://api.adviceslip.com/advice";

        HttpClient cliente = new HttpClient { BaseAddress = new Uri(url) };

        var response = await cliente.GetAsync("advice");

        var content = await response.Content.ReadAsStringAsync();

        

        var advice = JsonConvert.DeserializeObject<Temp>(content);

        Console.WriteLine(advice.Slip.Advice);

    }
    catch(Exception ex)
    {
        throw new Exception(ex.Message);
    }

}

static async Task AdviceWordAsync()
{
    try
    {
        Console.WriteLine("Write a word of a advice, which you wish receive");

        string query = Console.ReadLine();

        string url = $"https://api.adviceslip.com/advice/search/{query}";

        HttpClient cliente = new HttpClient { BaseAddress = new Uri(url) };

        var response = await cliente.GetAsync(query);

        var content = await response.Content.ReadAsStringAsync();

        var advice = JsonConvert.DeserializeObject<AdviceByQuery>(content);

        if (advice.Slips == null)
        {
            Console.WriteLine("Sorry but the API not have a advice for this word, try other word");
        }
        else
        {
            foreach (var item in advice.Slips)
            {
                Console.WriteLine(item.Advice);
            }
        }
    }
    catch (Exception ex)
    {
        throw new Exception(ex.Message);
    }
}