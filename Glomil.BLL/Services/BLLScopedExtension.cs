using Glomil.BLL.Abstract;
using Glomil.BLL.Concrete;
using Glomil.DAL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Services
{
   public static class BLLScopedExtension
    {
        public static void AddBLLObject(this IServiceCollection services)
        {
            services.AddDalObject();
            services.AddScoped<IUsersBLL, UsersBLL>();
            services.AddScoped<IQuestionAnswerBLL, QuestionAnswerBLL>();
        }
    }
}
