using System;
using System.Collections.Generic;
using System.Text;
using FastFood.Services.DTO.Category;

namespace FastFood.Services.Interfaces
{
    public interface ICategoryService
    {
        void Create(CreateCategoryDto dto);

        ICollection<ListAllCategoriesDto> All();
    }
}
