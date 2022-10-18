using AutoMapper;
using JapPlatformBackend.Common.Response;
using JapPlatformBackend.Core.Dtos.Admin;
using JapPlatformBackend.Core.Interfaces;
using JapPlatformBackend.Database;
using Microsoft.EntityFrameworkCore;

namespace JapPlatformBackend.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public AdminService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<GetReport>> GetReport()
        {
            var getOverallSuccess = await context.GetOverallSuccess.FromSqlRaw("GetOverallSuccess").ToListAsync();
            var getSelectionSuccess = await context.GetSelectionsSuccess.FromSqlRaw("GetSelectionsSuccess").ToListAsync();

            var report = new GetReport();
            report.OverallSuccessRate = getOverallSuccess.First().OverallSuccessRate;
            report.SelectionSuccessRate = getSelectionSuccess;

            var response = new ServiceResponse<GetReport>
            {
                Data = report,
            };

            return response;
        }

    }
}
