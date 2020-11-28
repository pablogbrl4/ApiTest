using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;

namespace WebTeste.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(ApplicationContext context) : base(context)
        {

        }

        public async Task<User> FazerLoginByUsuario(string codUsuario, string senhaUsuario)
        {
            var query =
                     _dbSet.Where(c => c.Login == codUsuario.ToLower())
                           .Where(c => c.password == senhaUsuario)
                               .FirstOrDefaultAsync();

            if (query != null)
            {
                return await query;
            }

            return null;
        }
    }
}
