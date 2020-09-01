using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoPatrimonio.Infra.Transactions
{
    public interface IUnityOfWork
    {
        void Commit();
    }
}
