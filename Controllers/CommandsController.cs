using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllComands()
        {
            var itemsList = _repository.GetAllComands();   

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(itemsList));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var item =  _repository.getCommandById(id);
            
            if(item != null){
                //mapojm prej itemit ne command read dto, dmth si paremeter e qojm itemin prej ku po vijne te dhenat
                return Ok(_mapper.Map<CommandReadDto>(item));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult AddCommand(CommandCreateDto command)
        {
          var result = _repository.AddCommand(_mapper.Map<Command>(command));
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