using System;
using CommandAPI.Models;

namespace CommandAPI.Data;

public class SqlCommandAPIRepo : ICommandAPIRepo
{
    private readonly CommandContext _context;
    public SqlCommandAPIRepo(CommandContext context)
    {
        _context = context;
    }

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
        return _context.CommandItems.ToList();
    }

    public Command GetCommandById(int id)
    {
        return _context.CommandItems.FirstOrDefault(c => c.Id == id);
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
