﻿using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Application.Commands
{
    public class ReserveSeatCommand : IRequest<ReserveSeatCommandComplete>
    {
        public string Id { get; set; }
    }

    public record ReserveSeatCommandComplete
    {
        public string Id { get; set; }
    }
}
