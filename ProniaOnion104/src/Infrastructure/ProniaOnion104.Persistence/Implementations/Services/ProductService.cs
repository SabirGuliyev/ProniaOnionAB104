using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion104.Application.Abstractions.Repositories;
using ProniaOnion104.Application.Abstractions.Services;
using ProniaOnion104.Application.DTOs.Products;
using ProniaOnion104.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion104.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductItemDto>> GetAllPaginated(int page,int take)
        {
            IEnumerable<ProductItemDto> dtos = _mapper.Map<IEnumerable<ProductItemDto>>(await _repository.GetAllWhere(skip:(page-1)*take,take:take,isTracking:false).ToArrayAsync());
            return dtos;
        }
        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product product=await _repository.GetByIdAsync(id,includes:nameof(Product.Category));
            ProductGetDto dto=_mapper.Map<ProductGetDto>(product);
            return dto;
        }
    }
}
