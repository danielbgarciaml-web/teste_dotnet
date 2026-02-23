namespace Veiculos.Application.Interfaces;

public interface IAuthService { string GerarToken(string login, Guid id); }