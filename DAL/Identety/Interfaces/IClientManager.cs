using System;
using DAL.Identety.Entities;

namespace DAL.Identety.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
