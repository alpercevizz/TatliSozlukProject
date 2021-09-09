using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorLoginManager : IAuthorLoginService
    {
        IAuthorDal _authorDal;

        public AuthorLoginManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public Author GetAuthor(string username, string password)
        {
           return  _authorDal.Get(x=>x.AuthorMail == username && x.AuthorPassword == password);
        }
    }
}
