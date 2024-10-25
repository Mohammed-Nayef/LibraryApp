using LibraryApp.Domain.Common.Classes;
using LibraryApp.Domain.Enums;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data.RepositoriesImplementations
{
   
    public class StoredProceduresRepository : IStoredProceduresRepository
    {
        private readonly DbContext context;

        // Do not Add Any Procedure That Returns A Complex Object That Has Non-primitive Properies UNTIL Registering it as a View 
        // See More About Using View : https://goatreview.com/stored-procedures-efcore-explained/

        public static readonly Dictionary<StoredProcedures, Type> ProcedureReturnType = new Dictionary<StoredProcedures, Type>()
        {
            {StoredProcedures.GetAllTags, typeof(TagFromProcedure)},
        };

        public StoredProceduresRepository(DbContext context)
        {
            this.context = context;
        }


        public List<TagFromProcedure> GetAllTags()
        {
            return context.Database
                .SqlQuery<TagFromProcedure>($"EXEC {StoredProcedures.GetAllTags.ToString()}")
                .ToList();
        }

        public List<object> ExecuteStoredProcedure(StoredProcedures procedureEnum)
        {
            throw new NotImplementedException();
        }
    }
}
