using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTeste.Models;

namespace WebTeste.Interfaces.Repositories
{

    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FazerLoginByUsuario(string codUsuario, string senhaUsuario);
    }
}
