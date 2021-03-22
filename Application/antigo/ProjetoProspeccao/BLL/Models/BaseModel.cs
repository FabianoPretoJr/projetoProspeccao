namespace BLL.Models
{
    public abstract class BaseModel
    {
        public BaseModel() { }

        public BaseModel(int id)
        {
            this.Id = id;
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private bool _ativo;
        public bool Ativo
        {
            get { return _ativo; }
            private set { _ativo = value; }
        }
    }
}
