Console.WriteLine("Hello, World!");

List<Tuple<string, int>> bids = new List<Tuple<string, int>>();
string input = "1,A,5,B,10,A,8,A,17,B,17";
string[] splitinput = input.Split(',');
int startingbid = int.Parse(splitinput[0]);
for (int i = 1; i < splitinput.Length; i+=2)
{
    bids.Add(new Tuple<string, int>(splitinput[i], int.Parse(splitinput[i + 1])));
}

int currentPrice = startingbid;
List<string> highestBidder = new List<string>();
List<int> highestBidderBid = new List<int>();
highestBidderBid.Add(0);
highestBidder.Add("");

Console.WriteLine($"1 startingBid {startingbid} {currentPrice} {highestBidder}");
for (var index = 1; index < bids.Count; index++)
{   
    var currentBid = bids[index];
    if (currentBid.Item2 > highestBidderBid[^1])
    {
        highestBidder.Add(currentBid.Item1);
        highestBidderBid.Add(currentBid.Item2); 
    }
    else
    {
        highestBidder.Add(highestBidder[^1]);
        highestBidderBid.Add(highestBidderBid[^1]); 
    }
    
    if (highestBidderBid[index - 1] == highestBidderBid[index])
    {
        currentPrice = currentBid.Item2+1;
    }
    else
    {
        currentPrice = highestBidderBid[GetIndexLastHighestBidderBid()]+1;
    }
    Console.WriteLine($"{index+1} {currentBid.Item1} {currentBid.Item2} {currentPrice} {highestBidder[index]}");
}

int GetIndexLastHighestBidderBid()
{
    for (int i = highestBidderBid.Count-1; i >= 0 ; i--)
    {
        if (highestBidderBid[i] != highestBidderBid[i + 1])
        {
            return i;
        }
    }
    throw new ArgumentException("scheisse");
}