using MediatR;
using TechTest.Models;

namespace TechTest.Queries;

public record GetContributorsQuery(string Owner, string Repository) : IRequest<IEnumerable<Commit>?>;