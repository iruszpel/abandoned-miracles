using System.Net;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Entities.Reports;
using AbandonedMiracle.Api.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedMiracle.Api.Commands.Reports;

public class CloseReport
{
    public class Command : IRequest<Unit>
    {
        public Guid ReportId { get; set; }
    }
    
    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly AmDbContext _context;

        public Handler(AmDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == request.ReportId);

            if (report is null)
            {
                throw new RestException(HttpStatusCode.NotFound, "Report not found");
            }
            
            if(report.Status == ReportStatus.Closed)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Report is already closed");
            }
            
            report.Status = ReportStatus.Closed;
            
            var success = await _context.SaveChangesAsync() > 0;
            
            if (success) return Unit.Value;
            
            throw new Exception("Problem saving changes");
        }
    }
}