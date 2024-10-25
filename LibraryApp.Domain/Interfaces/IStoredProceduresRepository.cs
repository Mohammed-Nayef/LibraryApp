using LibraryApp.Domain.Common.Classes;
using LibraryApp.Domain.Enums;
using LibraryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Domain.Interfaces
{
    public interface IStoredProceduresRepository
    {
        List<TagFromProcedure> GetAllTags();
        List<Object> ExecuteStoredProcedure(StoredProcedures procedureEnum);
    }
}
