using System;
using CommandAPI.Models;

namespace CommandAPI.Data;

public class MockCommandAPIRepo : ICommandAPIRepo
{
    public void CreateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
        var commands = new List<Command>
            {
            new Command{
            Id=0, HowTo="How to generate a migration",
            CommandLine="dotnet ef migrations add <Name of Migration>",
            Platform=".Net Core EF"},
            new Command{
            Id=1, HowTo="Run Migrations",
            CommandLine="dotnet ef database update",
            Platform=".Net Core EF"},
            new Command{
            Id=2, HowTo="List active migrations",
            CommandLine="dotnet ef migrations list",
            Platform=".Net Core EF"}
            };
        return commands;
    }

    public Command GetCommandById(int id)
    {
        return GetAllCommands().Where(c => c.Id == id).FirstOrDefault() ?? new Command();
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
        throw new NotImplementedException();
    }

}