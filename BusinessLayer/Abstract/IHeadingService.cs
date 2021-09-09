using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        List<Heading> GetHeadingListByAuthor(int id);
        void AddHeading(Heading heading);
        void UpdateHeading(Heading heading);
        void DeleteHeading(Heading heading);
        Heading GetById(int id);

    }
}
