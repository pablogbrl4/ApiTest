using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;
using WebTeste.Validator;

namespace WebTeste.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        protected readonly ITodoRepository _repository;
        protected readonly IValidator<Todo> _validator;

        public TodoController(ITodoRepository todoRepository, IValidator<Todo> todoValidator) 
        {
            _repository = todoRepository;
            _validator = todoValidator;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var list = await _repository.BuscarTodos();
                return new OkObjectResult(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Incluir([FromBody] Todo dado)
        {
            try
            {

                List<string> response = new List<string>();

                var validationResult = _validator.Validate(dado);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        response.Add(error.ToString());
                    }

                    return new OkObjectResult(response);
                }

                return new OkObjectResult(await _repository.Incluir(dado));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public TodoController(ITodoRepository todo) : base(todo)
        //{
        //    _todoRepository = todo;
        //}

        //readonly ApplicationContext Context;

        //public TodoController(ApplicationContext context) => Context = context;


        //[HttpGet]
        //public  IActionResult GetTodo()
        //{
        //    var todos = Context.Todo.ToList();

        //    return Ok(todos);
        //}


        //[HttpGet]
        //[Route("{id}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> SelecionarPorId(string id)
        //{
        //    try
        //    {
        //        var objById = await _repository.BuscarPorId(id);
        //        return new OkObjectResult(objById);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> Incluir([FromBody] Todo dado)
        //{
        //    try
        //    {
        //        return new OkObjectResult(await _repository.Cadastrar(dado));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public IActionResult CreateTodo()
        //{
        //    var todo = new Todo()
        //    {
        //        Title = "Do Laundry",
        //        Body = @"You're laundry is looking a little sad."

        //    };

        //    Context.Add(todo);
        //    Context.SaveChanges();

        //    return Ok("Succesfully create a todo item!");
        //}
    }
}
