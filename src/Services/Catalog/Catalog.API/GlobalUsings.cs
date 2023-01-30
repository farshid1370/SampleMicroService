// Global using directives

global using Catalog.API.Application.Features.Catalog.Commands.CreateCatalog;
global using Catalog.API.Application.Features.Catalog.Commands.UpdateNamePrice;
global using Catalog.API.Application.Features.Catalog.Queries.GetCatalog;
global using Catalog.API.Application.Features.Catalog.Queries.GetCatalogList;
global using Catalog.API.Grpc.Proto;
global using Catalog.Domain.AggregatesModel.CatalogAggregate;
global using Catalog.Domain.AggregatesModel.SupplierAggregate;
global using Grpc.Core;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using Catalog.API.Grpc.Services;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using System.Net;
global using System.Reflection;
global using Catalog.API.Infrastructure.ConfigurationExtensions;
global using Catalog.Infrastructure.Infrastructure;
global using Catalog.Infrastructure.Infrastructure.ConfigurationExtensions;
global using Catalog.Infrastructure;
global using Host;