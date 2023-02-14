using FileGroups;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
string fileName = @"C:\Users\Techno Clite\Desktop\Prüfung\03 - File + Groups\AYN_BRNCH_971025.txt";
string[] lines = File.ReadAllLines(fileName);
List<Branchs> branchs = new List<Branchs>();
foreach (string line in lines)
{
    var branchSplit = line.Split(",");

    branchs.Add(new Branchs
    {
        ProvinceCode = branchSplit[0].Trim(),
        ProvinceName = branchSplit[2].Trim(),
        BankCode = branchSplit[1].Trim(),
        CityCode = branchSplit[3].Trim(),
        CityName = branchSplit[4].Trim(),
        Branch = branchSplit[5].Trim(),
        BranchName = branchSplit[6].Trim(),
        Address = branchSplit[7].Trim(),
        PostalCode = branchSplit[8].Trim()
    }
);
}

//bayad bar asase provinceCode tedade shoab ro dar biyaram ....

//////////////////////////////////////////////////////////////////
var queryGetCountBranchByProvince = branchs.GroupBy(p => p.ProvinceName, (key, g) => new { ProvinceName = key, List = g.ToList() });

string output = "";
foreach (var i in queryGetCountBranchByProvince)
{
    output+=$"{i.ProvinceName},{i.List.Count}\n";
    foreach (var item in i.List)
    {
        output+=$"{item.ProvinceCode},{item.ProvinceName},{item.BankCode},{item.CityCode},{item.CityName},{item.BranchName}," +
            $"{item.Address},{item.PostalCode}\n";
    }
}
System.IO.File.WriteAllText(".\\1.txt", output);
var queryGetCountBranchByProvince1 = 
     from i in branchs
     group i by i.ProvinceName ;
 output = "";
foreach (var i in queryGetCountBranchByProvince1.ToList())
{
    output += $"{i.Key},{i.ToList().Count}\n";
    foreach (var item in i.ToList())
    {
        output += $"{item.ProvinceCode},{item.ProvinceName},{item.BankCode},{item.CityCode},{item.CityName},{item.BranchName}," +
            $"{item.Address},{item.PostalCode}\n";
    }
}
System.IO.File.WriteAllText(".\\2.txt",output);



//////////////////////////////////////////////////////////////////

//string provinceCode = "";

//for (int i = 1; i < branchs.Count; i++)
//{
//    tt[i] = $"{branchs[i].ProvinceCode},{branchs[i].ProvinceName},{branchs[i].BankCode},{branchs[i].CityCode},{branchs[i].CityName}," +
//        $"{branchs[i].CityName}, {branchs[i].Branch},{branchs[i].BranchName},{branchs[i].Address},{branchs[i].PostalCode}";
//}
//File.WriteAllLines("C:\\Users\\Techno Clite\\Desktop\\Prüfung\\03 - File + Groups\\New folder\\FileGroups.txt", tt);