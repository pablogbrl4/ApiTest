using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebTeste.Models;

namespace WebTeste.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        #region Escrita
        Task<int> Incluir(T entidade);

        Task<T> Alterar(T entidade);

        Task<bool> Excluir(int id);
        #endregion


        #region Leitura
        Task<T> BuscarPorId(int id);

        Task<IEnumerable<T>> BuscarTodos();

        Task<IEnumerable<T>> BuscarTodosComPesquisa(Expression<Func<T, bool>> expression);
        #endregion
    }
}
