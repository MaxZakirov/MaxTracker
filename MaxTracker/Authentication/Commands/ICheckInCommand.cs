using MaxTracker.Authentication.Models;

namespace MaxTracker.Authentication.Commands
{
	public interface ICheckInCommand
	{
		UserCheckinModel CheckinModel { get; set; }

		UserAuthenticationInfoViewModel Execute();
	}
}
