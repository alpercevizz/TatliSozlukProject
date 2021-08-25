using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList();
        List<Content> GetContentByHeadingId(int id);
        void AddContent(Content content);
        void UpdateContent(Content content);
        void DeleteContent(Content content);
        Content GetById(int id);
    }
}
