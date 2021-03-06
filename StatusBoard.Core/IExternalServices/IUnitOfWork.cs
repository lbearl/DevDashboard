﻿using System;
using System.Threading;
using System.Threading.Tasks;
using StatusBoard.Core.IRepositories;
using StatusBoard.Core.IRepositories.Identity;

namespace StatusBoard.Core.IExternalServices
{
    //I personally don't actually like this approach, I'm just using it for now, but may move to using an inverted and injected UoW approach
    //as detailed here: https://lostechies.com/derekgreer/2015/11/01/survey-of-entity-framework-unit-of-work-patterns/ (Unit Of Work Repository Manager)
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IServerRepository ServerRepository { get; }
        IServiceHistoryRepository ServiceHistoryRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion

    }
}
