using System;
using System.Text;
using AutoMapper;
using MaxTracker.Authentication.Commands;
using MaxTracker.Authentication.Models;
using MaxTracker.Authentication.Queries;
using MaxTracker.Domain.Items;
using MaxTracker.Domain.Rooms;
using MaxTracker.Domain.Users.Authentication;
using MaxTracker.Items.Commands;
using MaxTracker.Items.Models;
using MaxTracker.Items.Queries;
using MaxTracker.Persistence;
using MaxTracker.Persistence.Authentication;
using MaxTracker.Persistence.Items;
using MaxTracker.Persistence.Items.Models;
using MaxTracker.Persistence.Rooms;
using MaxTracker.Rooms;
using MaxTracker.Rooms.Commands;
using MaxTracker.Rooms.Queries;
using MaxTracker.Rooms.Stairs.Commands;
using MaxTracker.Rooms.Stairs.Queries;
using MaxTracker.Settings;
using MaxTracker.Users.Commands;
using MaxTracker.Users.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MaxTracker
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			this.InitializeAutoMapper();
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
			});
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			this.ConfigureJWT(services);
			this.ConfigureDepenpencyInjection(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
		}

		private void ConfigureJWT(IServiceCollection services)
		{
			var appSettingsSection = this.Configuration.GetSection("AppSettings");
			services.Configure<AppSettings>(appSettingsSection);
			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);

			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			 .AddJwtBearer(x =>
			 {
				 x.RequireHttpsMetadata = false;
				 x.SaveToken = true;
				 x.TokenValidationParameters = new TokenValidationParameters
				 {
					 ValidateIssuerSigningKey = true,
					 IssuerSigningKey = new SymmetricSecurityKey(key),
					 ValidateIssuer = false,
					 ValidateAudience = false
				 };
			 });
		}

		private void InitializeAutoMapper()
		{
			Mapper.Initialize(cnf => {
				cnf.CreateMap<UserCheckinModel, User>().ForMember(opt => opt.Role, d => d.Ignore());
				cnf.CreateMap<Item, MongoItemModel>().ForAllMembers(opt => opt.AllowNull());
				cnf.CreateMap<MongoItemModel, Item>().ForAllMembers(opt => opt.AllowNull());
				cnf.CreateMap<Item, ItemViewModel>().ForAllMembers(opt => opt.AllowNull());
				cnf.CreateMap<ItemViewModel, Item>().ForAllMembers(opt => opt.AllowNull());
			});
		}

		private void ConfigureDepenpencyInjection(IServiceCollection services)
		{
			services.AddScoped<IDbContext, MongoDbContext>();
			services.AddTransient<IAuthenticateQuery, AuthenticateQuery>();
			services.AddTransient<ICheckInCommand, CheckInCommand>();
			services.AddTransient<IUserRepository, MongoUserRepository>();
			services.AddTransient<IRoomRepository, MongoRoomRepository>();
			services.AddTransient<IItemRepository, MongoItemRepository>();
			services.AddTransient<IStairsRepository, MongoStairsRepository>();
			services.AddTransient<IBanUserCommand, BanUserCommand>();
			services.AddTransient<IUnbanUserCommand, UnbanUserCommand>();
			services.AddTransient<IGetAllUsersQuery, GetAllUsersQuery>();
			services.AddTransient<IGetAllItemTypesQuery, GetAllItemTypesQuery>();
			services.AddTransient<IGetAllItemsQuery, GetAllItemsQuery>();
			services.AddTransient<ICreateItemCommand, CreateItemCommand>();
			services.AddTransient<IUpdateItemCommand, UpdateItemCommand>();
			services.AddTransient<IDeleteItemCommand, DeleteItemCommand>();
			services.AddTransient<IToggleItemCommand, ToggleItemCommand>();
			services.AddTransient<IItemTypeRepository, MongoItemTypeRepository>();
			services.AddTransient<ISetNewRoleToUserCommand, SetNewRoleToUserCommand>();
			services.AddTransient<ICreateRoomCommand, CreateRoomCommand>();
			services.AddTransient<IDeleteRoomCommand, DeleteRoomCommand>();
			services.AddTransient<IUpdateRoomCommand, UpdateRoomCommand>();
			services.AddTransient<IGetAllRoomsQuery, GetAllRoomsQuery>();
			services.AddTransient<ICreateStairsCommand, CreateStairsCommand>();
			services.AddTransient<IDeleteStairsCommand, DeleteStairsCommand>();
			services.AddTransient<IUpdateStairsCommand, UpdateStairsCommand>();
			services.AddTransient<IGetAllStairsQuery, GetAllStairsQuery>();
			services.AddTransient<IRoomService, RoomService>();
		}
	}
}
