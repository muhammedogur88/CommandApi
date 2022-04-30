using System;

namespace CommandAPI.Models;

public class Command
{
    public int Id { get; set; }
    public string HowTo { get; set; }
    public string Platfrom { get; set; }
    public string CommandLine { get; set; }
}