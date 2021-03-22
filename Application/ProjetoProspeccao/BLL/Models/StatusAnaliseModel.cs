namespace BLL.Models
{
    public class StatusAnaliseModel : BaseModel
    {
        public StatusAnaliseModel(string nomeStatus)
        {
            this.NomeStatus = nomeStatus;
        }

        public StatusAnaliseModel(int id, string nomeStatus) : base(id)
        {
            this.NomeStatus = nomeStatus;
        }

        private string _nomeStatus;
        public string NomeStatus
        {
            get { return _nomeStatus; }
            private set { _nomeStatus = value; }
        }
    }
}
