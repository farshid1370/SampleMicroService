// Global using directives

global using System.Data.Common;
global using Catalog.API.Application.Features.Catalog.Commands.CreateCatalog;
global using Catalog.API.Application.Features.Catalog.Commands.UpdateNamePrice;
global using Catalog.API.Application.Features.Catalog.Queries.GetCatalog;
global using Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;
global using Catalog.Domain.AggregatesModel.CatalogAggregate;
global using Catalog.Domain.AggregatesModel.SupplierAggregate;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Catalog.API.Grpc.ServerServices;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using System.Net;
global using System.Reflection;
global using Catalog.API;
global using Catalog.API.Application.Behaviors;
global using Catalog.API.Application.Features.Catalog.Commands.UpdateStock;
global using Catalog.API.Application.Features.Catalog.Queries.GetSupplier;
global using Catalog.API.Exceptions;
global using Catalog.API.Grpc.Proto;
global using Catalog.API.Infrastructure.ConfigurationExtensions;
global using Catalog.Infrastructure.Infrastructure.ConfigurationExtensions;
global using Catalog.Infrastructure;
global using Common.Integration;
global using Common.Integration.Events;
global using Grpc.Core;
global using IntegrationEventEF.Service;
global using MassTransit;
global using Catalog.API.Application.Integration;
global using Catalog.API.BackgroundServices;
global using Catalog.API.Infrastructure.Extensions;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;