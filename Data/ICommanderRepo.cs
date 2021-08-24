using System.Collections.Generic;
using System.Threading.Tasks;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllComands();
        Command getCommandById(int id);
        bool AddCommand(Command command);
        Command EditCommand(int id);
        Command DeleteCommand(int id);
        bool SaveChanges();


    }
}