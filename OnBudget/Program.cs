using Microsoft.EntityFrameworkCore;
using OnBudget.BL.Services.CategoryService;
using OnBudget.BL.Services.CustomerService;
using OnBudget.BL.Services.LoginService;
using OnBudget.BL.Services.OrderService;
using OnBudget.BL.Services.PictureService;
using OnBudget.BL.Services.ProductService;
using OnBudget.BL.Services.RegistrationService;
using OnBudget.BL.Services.ShipperService;
using OnBudget.BL.Services.SupplierService;
using OnBudget.DA.AppContext;
using OnBudget.DA.Repository.CategoryRepo;
using OnBudget.DA.Repository.CustomerRepo;
using OnBudget.DA.Repository.PictureRepo;
using OnBudget.DA.Repository.ProductRepo;
using OnBudget.DA.Repository.ShipperRepo;
using OnBudget.DA.Repository.SupplierRepo;

namespace OnBudget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
            });
            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddScoped<ISupplierService, SupplierService>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
            builder.Services.AddScoped<IShipperService, ShipperService>();

            builder.Services.AddScoped<IRegistrationService, RegistrationService>();

            builder.Services.AddScoped<ILoginService, LoginService>();

            builder.Services.AddScoped<IPictureService, PictureService>();
            builder.Services.AddScoped<IPictureRepository, PictureRepository>();

            var app = builder.Build();

            app.UseAuthorization();

            app.UseCors();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.MapControllers();

            app.Run();
        }
    }
}