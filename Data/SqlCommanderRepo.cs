using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public bool AddCommand(Command command)
        {
            if(command == null){
                return false;
            }

            _context.Commands.Add(command);

          var res = SaveChanges();

            return res;
        }

        public IEnumerable<Command> GetAllComands()
        {
            var commands = _context.Commands.ToList();

            return commands;
        }

        public Command getCommandById(int id)
        {
            return _context.Commands.Where(c => c.Id == id).FirstOrDefault();
        }

        public Command EditCommand(int id)
        {
            return _context.Commands.Where(c => c.Id == id).FirstOrDefault();
        }

        public Command DeleteCommand(int id)
        {
            var result = _context.Commands.FirstOrDefault(c => c.Id == id);

            if(result != null )
            {
                _context.Commands.Remove(result);

                SaveChanges();

                return result;
            }
            return null;
        }
        public bool SaveChanges()
        {
            var res = _context.SaveChanges();

            if(res > 0){
                return true;
            }
            return false;
        }

    }

}
    
