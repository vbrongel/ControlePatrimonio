namespace GerenciamentoPatrimonio.Infra.Transactions
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly Context _context;

        public UnityOfWork(Context context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}