﻿using System;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer:IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BasketCheckoutConsumer(IMediator mediator,IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
        }
    }
}

