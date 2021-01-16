using System;
using EventoCore.Domain;
using EventoInfrastructure.DTO.Jwt;

namespace EventoInfrastructure.Services.Jwt {

    public interface IJwtService {

        JwtDTO CreateToken(Guid userId, UserRole role);

    }

}
