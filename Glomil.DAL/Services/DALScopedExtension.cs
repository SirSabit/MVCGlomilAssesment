using Glomil.DAL.Repositories.Abstract;
using Glomil.DAL.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.DAL.Services
{
    public static class DALScopedExtension
    {
        public static void AddDalObject(this IServiceCollection services)
        {
            services.AddScoped<IUsersDal, UsersDal>();
            services.AddScoped<IQuestionAnswerDal, QuestionAnswerDal>();
        }
    }
}
