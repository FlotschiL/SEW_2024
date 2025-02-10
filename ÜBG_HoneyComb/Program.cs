string level = "level1_5";
StreamReader sr = new StreamReader("C:\\Users\\MainUserFlo\\Downloads\\level2\\"+ level + ".in");
string[] level1InLines = sr.ReadToEnd().Split('\n');
int height = level1InLines.Length-1;
int width = level1InLines[0].Split("-").Length-1;
string[,] hive = new string[height,width];
for (int x = 0; x < height; x++)
{
    
}
    
sr.Close();
StreamWriter sw = new StreamWriter("C:\\Users\\MainUserFlo\\Downloads\\level2\\" + level + ".out");
sw.WriteLine(height*width + "");
sw.Close();
Console.WriteLine(height*width + "");