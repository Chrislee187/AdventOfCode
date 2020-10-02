using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2015_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"-?\d+";

            // var test = @"[[""green"",[{""e"":""green"",""a"":77,""d"":{""c"":""violet"",""a"":""yellow"",""b"":""violet""},""c"":""yellow"",""h"":""red"",""b"":144";//,""g"":{""a"":[""yellow"",-48,72,87,{""e"":""violet"",""c"":123,""a"":101,""b"":87,""d"":""red"",""f"":88},{""e"":""red"",""c"":2,""a"":1,""g"":""blue"",""b"":""green"",""d"":""violet"",""f"":170},""orange"",171,162]},""f"":""orange"",""i"":""orange""},49,[{""c"":{""e"":""violet"",""a"":-44,""d"":115,""c"":117,""h"":194,""b"":{""e"":-17,""a"":172,""d"":""green"",""c"":197,""h"":53,""b"":106,""g"":""violet"",""f"":-10},""g"":""red"",""f"":""orange""},""a"":-49,""b"":[""violet"",""orange"",""blue""]}],""green""]],[""orange""],{""e"":""blue"",""a"":[""red"",""yellow""],""d"":{""a"":[{""c"":{""a"":181,""b"":[""orange"",-40,""red"",""orange"",""yellow"",31,60,71,""yellow""]},""a"":[114,-40],""b"":""orange""},[""green"",93,10,{""c"":11,""a"":170,""b"":[161,-3],""d"":-16},58,{""e"":{""c"":-2,""a"":117,""b"":""violet""},""c"":[""blue"",""yellow"",""red"",""violet"",""yellow"",123,113],""a"":""orange"",""g"":19,""b"":108,""d"":""red"",""f"":""yellow""},{""e"":""green"",""c"":""yellow"",""a"":{""e"":28,""c"":""red"",""a"":""violet"",""b"":""red"",""d"":""green""},""g"":""yellow"",""b"":116,""d"":148,""f"":""red""},[15],[""green"",""green"",43],""blue""],[133],""green"",134,""violet"",{""c"":""red"",""a"":[71,41,""blue""],""b"":""yellow"",""d"":""violet""},132,[10,""violet"",[182,""green"",""green"",""orange""],78,{""c"":""blue"",""a"":[100,-36,""blue"",""violet"",-10,""orange""],""b"":{""e"":""orange"",""c"":""blue"",""a"":160,""g"":""green"",""b"":190,""d"":""red"",""f"":186}},16],[{""c"":""green"",""a"":""violet"",""b"":20,""d"":""red""},""green"",""blue"",{""c"":[0,84,184,""orange"",-34,""blue"",""orange"",0,""violet"",""violet""],""a"":10,""b"":89},""green"",182,127,-2,196]]},""c"":-20,""h"":[[165,[180,""yellow"",-5,16,""red"",";

            var regex = new Regex(pattern);
            var data = File.ReadAllText("data.txt");

            var match = regex.Matches(data);

            var sum = match.Select(m => int.Parse(m.Value)).Sum();

            Console.WriteLine($"Sum: {sum}");
            
            
        }
    }
}
