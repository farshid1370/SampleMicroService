using Catalog.Domain.AggregatesModel.SupplierAggregate;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Catalog.API.Application.Features.Catalog.Queries.GetSupplier;

public class SupplierItemVM
{
    public Guid Id { get; set; }
    public int RequestNumber { get; set; }
}