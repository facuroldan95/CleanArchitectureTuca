using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommand : IRequest<string>
    {
        public string Nombre { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

    }
}
