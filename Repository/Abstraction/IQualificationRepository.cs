using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Abstraction
{
    public interface IQualificationRepository : IRepository<Qualification>
    {
        IEnumerable<Qualification> GetAll();

        Qualification GetQualificationById(int Id);

        int AddQualification(Qualification qualification);
        int UpdateQualification(Qualification qualification);

        int DeleteQualification(int Id);

    }
}
