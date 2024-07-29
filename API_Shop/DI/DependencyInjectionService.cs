using BLL_Shop.DTO.Address.Create;
using BLL_Shop.DTO.Address.Update;
using BLL_Shop.DTO.Article.Create;
using BLL_Shop.DTO.Article.Update;
using BLL_Shop.DTO.Category.Create;
using BLL_Shop.DTO.Category.Update;
using BLL_Shop.DTO.Order.Create;
using BLL_Shop.DTO.Order.Update;
using BLL_Shop.DTO.User.Create;
using BLL_Shop.DTO.User.Update;
using BLL_Shop.Interfaces;
using BLL_Shop.JWT.Models;
using BLL_Shop.JWT.Services;
using BLL_Shop.Services;
using BLL_Shop.Validators.Address_Validator;
using BLL_Shop.Validators.Article_Validator;
using BLL_Shop.Validators.Category_Validator;
using BLL_Shop.Validators.Order_Validator;
using BLL_Shop.Validators.User_Validator;
using DAL_Shop.Interfaces;
using DAL_Shop.Repository;

using FluentValidation;


namespace API_Shop.DI
{
    public static class DependencyInjectionService
    {
        public static void ConfigurationDependencyInjection(IServiceCollection services, IConfiguration options)
        {
            //USER
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserServices>();

            //USER VALIDATOR
            services.AddScoped<IValidator<UserCreateDTO>, UserCreateValidator>();
            services.AddScoped<IValidator<UserUpdateDTO>, UserUpdateValidator>();
            services.AddScoped<IValidator<UserPseudoUpdateDTO>, UserPseudoUpdateValidator>();
            services.AddScoped<IValidator<UserMailUpdateDTO>, UserMailUpdateValidator>();
            services.AddScoped<IValidator<UserPwdUpdateDTO>, UserPwdUpdateValidator>();


            //ADDRESS
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            //ADDRESS VALIDATOR
            services.AddScoped<IValidator<AddressCreateDTO>, AddressCreateValidator>();
            services.AddScoped<IValidator<AddressCountryUpdateDTO>, AddressUpdateValidator>();
            services.AddScoped<IValidator<AddressCityUpdateDTO>, AddressUpdateCityValidator>();
            services.AddScoped<IValidator<AddressPhoneNumberUpdateDTO>, AddressUpdatePhoneNumberValidator>();


            //ARTICLE
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleService, ArticleService>();

            //ARTICLE VALIDATOR
            services.AddScoped<IValidator<ArticleCreateDTO>, ArticleCreateValidator>();
            services.AddScoped<IValidator<ArticleUpdateDTO>, ArticleUpdateValidator>();
            services.AddScoped<IValidator<ArticleNameUpdateDTO>, ArticleUpdateNameValidator>();
            services.AddScoped<IValidator<ArticlePriceUpdateDTO>, ArticleUpdatePriceValidator>();
            services.AddScoped<IValidator<ArticlePromoUpdateDTO>, ArticleUpdatePromoValidator>();
            services.AddScoped<IValidator<ArticleStockUpdateDTO>, ArticleUpdateStockValidator>();

            //CATEGORY
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            //CATEGORY VALIDATOR
            services.AddScoped<IValidator<CategoryCreateDTO>, CategoryCreateValidator>();
            services.AddScoped<IValidator<CategoryUpdateDTO>, CategoryUpdateValidator>();

            //ORDER
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            //ORDER VALIDATOR
            services.AddScoped<IValidator<OrderCreateDTO>, OrderCreateValidator>();
            services.AddScoped<IValidator<OrderSentAtUpdateDTO>, OrderUpdateSentAtValidator>();
            services.AddScoped<IValidator<OrderStatusAndSentAtUpdateDTO>, OrderUpdateStatusAndSentAtValidator>();
            services.AddScoped<IValidator<OrderStatusUpdateDTO>, OrderUpdateStatusValidator>();

            //AUTHENTICATION
            services.AddScoped<IAuthentificationCustomRepository, AuthenticationCustomRepository>();
            services.AddScoped<IAuthentificationCustomService, AuthenticationCustomService>();


            //JWT
            services.Configure<JWTSettings>(options.GetSection("JWT"));
            services.AddTransient<JWTGenerationService>();
            services.AddTransient<JWTGetClaimsService>();


            //HTTP CONTEXT
            services.AddHttpContextAccessor();
        }
    }
}
