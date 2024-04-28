using app.Dtos;
using app.Migrations;
using app.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Repositorys
{
    
    public interface IProductRepository
    {
        Task<IEnumerable<Producto>> Get();
        Task<Producto> GetByid(int Id);
        Task Insert(ProductoDto producto);

        Task Update( int id ,ProductoDto producto);

        Task Delete(int Id);
    }

    public class ProductRepository : IProductRepository
    {
        public readonly productosContext _productosContext;
        public ProductRepository(productosContext productosContext)
        {

            _productosContext = productosContext;
        }

        public async Task<IEnumerable<Producto>> Get()
        {
            var productoss = await _productosContext.Productos.ToListAsync();

            return productoss;
        }


        public async Task<Producto> GetByid(int Id)
        {
            var Productoo = await _productosContext.Productos.FindAsync(Id);


            return Productoo!;
        }

        public async Task Insert(ProductoDto producto)
        {
            var NewProduct = new Producto();

            NewProduct.Id = producto.Id;
            NewProduct.Nombre = producto.Nombre;
            NewProduct.Precio = producto.Precio;
            NewProduct.Descripcion = producto.Descripcion;

            _productosContext.Productos.Add(NewProduct);
            await _productosContext.SaveChangesAsync();
        }

        public async Task Update(int id, ProductoDto producto)
        {
            var productos = await _productosContext.Productos.FindAsync(id);

            productos!.Nombre = producto.Nombre;
            productos.Descripcion = producto.Descripcion;
            productos.Precio = producto.Precio;
            await _productosContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var ProductoBorrado = await _productosContext.Productos.FindAsync(id);

            _productosContext.Remove(ProductoBorrado!);

            await _productosContext.SaveChangesAsync();
        }
    }



    }
