using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{
    public class TodoRepository : BaseRepository<Todo>, ITodoRepository
    {

        public TodoRepository(ApplicationContext context) : base(context)
        {

        }

        //public async Task<Todo> Cadastrar(Todo todo)
        //{
        //    await _context.Todo.AddAsync(todo);
        //    _context.SaveChanges();
        //    return todo;
        //}

    }
}
