using System;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq; // HackerRank usually provides Newtonsoft.Json

class Result
{
    /*
     * Complete the 'getNumDraws' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER year as parameter.
     */

    public static int getNumDraws(int year)
    {
        int totalDraws = 0;
        try
        {
            for (int goals = 0; goals <= 10; goals++)
            {
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1goals={goals}&team2goals={goals}";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResponse = reader.ReadToEnd();
                    JObject json = JObject.Parse(jsonResponse);

                    totalDraws += (int)json["total"];
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return totalDraws;
    }
}
