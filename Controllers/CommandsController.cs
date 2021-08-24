using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllComands()
        {
            var itemsList = _repository.GetAllComands();   

            return Ok(itemsList);
        }

        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var item =  _repository.getCommandById(id);

            return Ok(item);
        }

        [HttpPost]
        public ActionResult AddCommand(Command command)
        {
          var result = _repository.AddCommand(command);
            if(result){
                return Ok();
            }else{
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public ActionResult EditCommand(int id, Command command)
        {
            var existingCommand = _repository.EditCommand(id);

            if(existingCommand != null)
            {
                existingCommand.HowTo = command.HowTo;

                existingCommand.Line = command.Line;

                existingCommand.Platform = command.Platform;

                _repository.SaveChanges();
            }
            else
            {
                var result = _repository.AddCommand(command);

                if(result){
                    return Ok("Command added.");
                }else{
                    return BadRequest("Couldn't add this command.");
                }
            }

            return Ok("Command edited successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var existingCommand = _repository.getCommandById(id);

            if(existingCommand != null)
            {
                return Ok(_repository.DeleteCommand(id));
            }
            return NotFound();
        }
    }
}