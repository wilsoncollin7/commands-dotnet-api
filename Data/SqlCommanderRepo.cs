using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
      _context = context;
    }

    public bool SaveChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    IEnumerable<Command> ICommanderRepo.GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    Command ICommanderRepo.GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public void CreateCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Add(cmd);
    }

    public void UpdateCommand(Command cmd)
    {
      // Nothing
    }

    public void DeleteCommand(Command cmd)
    {
      if (cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Remove(cmd);
    }
  }
}