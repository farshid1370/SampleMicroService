// Global using directives

global using System.Net;
global using System.Reflection;
global using Basket.API.Application.Features.Basket.Commands.UpdateBasket;
global using Basket.API.Application.Features.Basket.Commands.UpdateBasketCatalogPrice;
global using Basket.API.Application.Features.Basket.Queries.GetCustomerBasket;
global using Basket.API.Grpc.ClientServices;
global using Basket.Domain.AggregatesModel.BasketAggregate;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Basket.API.Infrastructure.ConfigurationExtensions;
global using Basket.Infrastructure.Infrastructure.ConfigurationExtensions;
global using Common.Integration;
global using Common.Integration.Events;
global using MassTransit;
global using Catalog.API.Grpc.Proto;
 