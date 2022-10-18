using desafio.Context;
using desafio.Entity;

namespace desafio.Repository
{
    public class MemberRepository: IMemberRepository
    {
        private readonly EFContext _dataContext;

        public MemberRepository(EFContext dataContext){
            _dataContext = dataContext;
        }

        public void Add(MemberEntity entity) {
            _dataContext.Members.Add(entity);
            _dataContext.SaveChanges();
        }
        public IEnumerable<MemberEntity> Get()
        {
            return _dataContext.Members.ToList();
        }
        public MemberEntity Get(int id)
        {
            return _dataContext.Members.FirstOrDefault(x => x.id == id);
        }

        public List<MemberEntity> GetAll(int page, int pageLimit)
        {
            return _dataContext.Members.Skip((page - 1) * pageLimit).Take(pageLimit).ToList();
        }

        public void Delete(int id)
        {
            MemberEntity entity = Get(id);
            _dataContext.Members.Remove(entity);            
            _dataContext.SaveChanges();
        }
        public int Count() {
            return _dataContext.Members.Count();
        }
        
    }
}