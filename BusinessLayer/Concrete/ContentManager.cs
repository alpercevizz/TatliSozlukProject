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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content content)
        {
            _contentDal.Insert(content);
        }

        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetContentByAuthor(int id)
        {
            return _contentDal.List(x => x.AuthorID == id);
        }

        public List<Content> GetContentByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetContentList(string p)
        {
            return _contentDal.List(x=>x.ContentText.Contains(p));
        }

        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
