using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreniDataModel.Models;

namespace TreniWebApi.Controllers
{
    public class MainController : ControllerBase
    {
        public TreniDbContext _dbContext { get; set; }

        protected MainController(DbContextOptions options, TreniDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
        }
    }
}
