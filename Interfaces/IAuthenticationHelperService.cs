﻿using _2Good2EatBackendStore.Models;

namespace _2Good2EatBackendStore.Interfaces
{
    public interface IAuthenticationHelperService
    {
        ImagekitAuthModel ProcessImagekitAuthenticationToken();
        string HashPassword(string password);

    }
}
