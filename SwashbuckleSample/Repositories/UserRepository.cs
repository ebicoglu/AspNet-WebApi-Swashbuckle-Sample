using System.Collections.Generic;
using System.Linq;
using SwashbuckleSample.Models;

namespace SwashbuckleSample.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            return Context.Users.Values.ToList();
        }

        public void Add(User item)
        {
           Context.Users.Add(item.Id, item);
        }

        public User Find(int id)
        {
            return Context.Users.Values.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
           Context.Users.Remove(id);
        }

        public void Update(User item)
        {
            Context.Users[item.Id] = item;
        }
    }
}