using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreniDataModel.Models;

namespace TreniWebApi.Controllers
{
    public class MainController : ControllerBase
    {
        public TreniDbContext _dbContext { get; set; }
        protected readonly IConfiguration _configuration;

        public MainController(TreniDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
    }
}
