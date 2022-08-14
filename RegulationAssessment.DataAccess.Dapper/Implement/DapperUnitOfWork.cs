using RegulationAssessment.DataAccess.Dapper.Interface;

namespace RegulationAssessment.DataAccess.Dapper.Implement
{
    public class DapperUnitOfWork : IDapperUnitOfWork
    {
        private readonly string ConnectionString;
        private IDapperRepository IRARepository;

        public DapperUnitOfWork(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDapperRepository RARepository
        {
            get { return IRARepository ?? (IRARepository = new DapperRepository(ConnectionString)); }
            set { IRARepository = value; }
        }
    }
}
