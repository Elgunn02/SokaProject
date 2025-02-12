﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Soka.Domain.Business.BrandModule
{
    public class BrandSingleQuery : IRequest<Brand>
    {
        public int Id { get; set; }
        public class BrandSingleQueryHandler : IRequestHandler<BrandSingleQuery, Brand>
        {
            private readonly SokaDbContext db;

            public BrandSingleQueryHandler(SokaDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                return entity;
            }
        }
    }
}
