using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace Application.Features.Users.Rules;

public class UserBusinessRules(IUserRepository userRepository) : BaseBusinessRules
{
    public Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            throw new BusinessException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public async Task UserIdShouldBeExistsWhenSelected(int id)
    {
        bool doesExist = await userRepository.AnyAsync(predicate: u => u.Id == id, enableTracking: false);
        if (doesExist)
            throw new BusinessException(AuthMessages.UserDontExists);
    }

    public Task UserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }

    public async Task UserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await userRepository.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    public async Task UserEmailShouldNotExistsWhenUpdate(int id, string email)
    {
        bool doesExists = await userRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }
}