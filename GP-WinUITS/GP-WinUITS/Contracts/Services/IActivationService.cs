namespace GP_WinUITS.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
