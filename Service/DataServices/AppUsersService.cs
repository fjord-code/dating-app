using Abstractions;
using AutoMapper;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Service.DataServices;

public interface IAppUsersService
{
    Task<List<AppUserDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AppUserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}

public class AppUsersService : IAppUsersService
{
    private readonly IMapper _mapper;
    private readonly IAppUsersRepository _repository;

    public AppUsersService(
        IMapper mapper,
        IAppUsersRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<AppUserDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _repository.GetAll().ToListAsync(cancellationToken);
        return _mapper.Map<List<AppUserDto>>(users);    
    }

    public async Task<AppUserDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var user = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<AppUserDto?>(user);
    }
}
