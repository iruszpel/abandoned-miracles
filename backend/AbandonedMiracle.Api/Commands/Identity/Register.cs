using System.Net;
using AbandonedMiracle.Api.DataAccess;
using AbandonedMiracle.Api.Dtos.Identity;
using AbandonedMiracle.Api.Entities.Identity;
using AbandonedMiracle.Api.Exceptions;
using AbandonedMiracle.Api.Helpers;
using AbandonedMiracle.Api.Services;
using AbandonedMiracle.Api.Settings;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AbandonedMiracle.Api.Commands.Identity;

public class Register
{
    public class Command : IRequest<UserWithTokenDto>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
    }

    public class Handler : IRequestHandler<Command, UserWithTokenDto>
    {
        private readonly UserManager<AmUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AmDbContext _dbContext;
        private readonly IJwtService _jwtService;

        public Handler(UserManager<AmUser> userManager, IMapper mapper, AmDbContext dbContext, IJwtService jwtService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
            _jwtService = jwtService;
        }

        public async Task<UserWithTokenDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = new AmUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var tran = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            
            try
            {
                var result = (await _userManager.CreateAsync(user, request.Password),
                    await _userManager.AddToRoleAsync(user, AmRole.RegularUser));
                if (!result.Item1.Succeeded || !result.Item2.Succeeded)
                {
                    throw new RestException(HttpStatusCode.InternalServerError, "Something went wrong. Try again later.");
                }
                await tran.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await tran.RollbackAsync(cancellationToken);
                throw new RestException(HttpStatusCode.InternalServerError, "Something went wrong. Try again later.");
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new UserWithTokenDto
            {
                Email = user.Email,
                Token = await _jwtService.GenerateJwtToken(user)
            };
        }
    }
}