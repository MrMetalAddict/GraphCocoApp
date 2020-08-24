using System.Collections.Generic;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphCocoApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConnectContext>();

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<Query>()
                    .Create(),
                new QueryExecutionOptions { ForceSerialExecution = true });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // use graphQL middleware
            app.UseGraphQL();

            app.UsePlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

        // Ensures that our database is created and seeds some initial data so that we can do some queries.
        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ConnectContext>();
                if (context.Database.EnsureCreated())
                {
                    context.ConnectUsers.Add(new ConnectUser
                    {
                        Id = "michael.scott@medtronic.com",
                        Name = "Michael Scott",
                        Accesses = new List<Access>
                        {
                            new Access()
                            {
                                AppId = "CC" ,
                                Roles = new List<Role>()
                                {
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104120",
                                        RoleId = 987546
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104500",
                                        RoleId = 9876511
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000105100",
                                        RoleId = 9876519
                                    }
                                }
                            }
                        },
                        Customers = new List<Customer>()
                        {
                            new Customer()
                            {
                                CustomerId = "MDT_0000104120",
                                Name = "Dunder Mifflin",
                                SoldToId = "0000105106",
                                TerritoryId = "MDTCOVUS"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000106847",
                                Name = "The Michael Scott Paper Company(Hospital)",
                                SoldToId = "0000106847",
                                TerritoryId = "MDTCHN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000107630",
                                Name = "0000107630 OPEN Level 4 Manager #2",
                                SoldToId = "0000107630",
                                TerritoryId = "MDTIT"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000108143",
                                Name = "0000108143 MATTHEW G GOETZ",
                                SoldToId = "0000108143",
                                TerritoryId = "MDTIN"
                            }
                        }
                    });
                    context.ConnectUsers.Add(new ConnectUser
                    {

                        Id = "dwight.schrute@medtronic.com",
                        Name = "Dwight Schrute",
                        Accesses = new List<Access>
                        {
                            new Access()
                            {
                                AppId = "Channel_Connect" ,
                                Roles = new List<Role>()
                                {
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104120_1",
                                        RoleId = 987546
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104500_2",
                                        RoleId = 9876511
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000105100_3",
                                        RoleId = 9876519
                                    }
                                }
                            }
                        },
                        Customers = new List<Customer>()
                        {
                            new Customer()
                            {
                                CustomerId = "MDT_0000104120_Dwight",
                                Name = "Assistant to the regional manager hospital",
                                SoldToId = "0000105106",
                                TerritoryId = "MDTCOVUS"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000106847_Dwight",
                                Name = "0000106847 PATRICK E BROWN",
                                SoldToId = "0000106847",
                                TerritoryId = "MDTCHN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000107630_Dwight",
                                Name = "0000107630 OPEN Level 4 Manager #2",
                                SoldToId = "0000107630",
                                TerritoryId = "MDTIT"
                            },
                        }
                    });
                    context.ConnectUsers.Add(new ConnectUser
                    {

                        Id = "jim.halpert@medtronic.com",
                        Name = "Jim Halpert",
                        Accesses = new List<Access>
                        {
                            new Access()
                            {
                                AppId = "estore_EMEA" ,
                                Roles = new List<Role>()
                                {
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104120_Jim",
                                        RoleId = 987546
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104500_Jim",
                                        RoleId = 9876511
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000105100_Jim",
                                        RoleId = 9876519
                                    }
                                }
                            }
                        },
                        Customers = new List<Customer>()
                        {
                            new Customer()
                            {
                                CustomerId = "MDT_0000104120_Jim",
                                Name = "Michael's Last Dundies",
                                SoldToId = "0000105106_Jim",
                                TerritoryId = "MDTCOVUS"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000106847_Jim",
                                Name = "0000106847 PATRICK E BROWN",
                                SoldToId = "0000106847_Jim",
                                TerritoryId = "MDTCHN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000107630_Jim",
                                Name = "0000107630 OPEN Level 4 Manager #2",
                                SoldToId = "0000107630_Jim",
                                TerritoryId = "MDTIT"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000108143_Jim",
                                Name = "0000108143 MATTHEW G GOETZ",
                                SoldToId = "0000108143_Jim",
                                TerritoryId = "MDTIN"
                            }
                        }
                    });
                    context.ConnectUsers.Add(new ConnectUser
                    {

                        Id = "ryan.howard@medtronic.com",
                        Name = "Ryan Howard",
                        Accesses = new List<Access>
                        {
                            new Access()
                            {
                                AppId = "eStore" ,
                                Roles = new List<Role>()
                                {
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104120_Ryan",
                                        RoleId = 987546
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104500_Ryan",
                                        RoleId = 9876511
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000105190_Ryan",
                                        RoleId = 9876519
                                    }
                                }
                            }
                        },
                        Customers = new List<Customer>()
                        {
                            new Customer()
                            {
                                CustomerId = "MDT_0000104120_Ryan",
                                Name = "Dunder Mifflin Infinity",
                                SoldToId = "0000105106",
                                TerritoryId = "MDTCOVUS"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000106847_Ryan",
                                Name = "0000106847 PATRICK E BROWN",
                                SoldToId = "0000106847",
                                TerritoryId = "MDTCHN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000107630_Ryan",
                                Name = "0000107630 OPEN Level 4 Manager #2",
                                SoldToId = "0000107630",
                                TerritoryId = "MDTIT"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000108143_Ryan",
                                Name = "0000108143 MATTHEW G GOETZ",
                                SoldToId = "0000108143",
                                TerritoryId = "MDTIN"
                            }
                        }
                    });
                    context.ConnectUsers.Add(new ConnectUser
                    {

                        Id = "kevin.malone@medtronic.com",
                        Name = "Kevin Malone",
                        Accesses = new List<Access>
                        {
                            new Access()
                            {
                                AppId = "OIP" ,
                                Roles = new List<Role>()
                                {
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104120_kevin",
                                        RoleId = 987546
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000104500_Kevin",
                                        RoleId = 9876511
                                    },
                                    new Role()
                                    {
                                        CustomerID = "MDT_0000105100_Kevin",
                                        RoleId = 9876519
                                    }
                                }
                            }
                        },
                        Customers = new List<Customer>()
                        {
                            new Customer()
                            {
                                CustomerId = "MDT_0000104120_Kevin",
                                Name = "Whistleblower",
                                SoldToId = "0000105106",
                                TerritoryId = "MDTCOVUS"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000106847_Kevin",
                                Name = "0000106847 PATRICK E BROWN",
                                SoldToId = "0000106847",
                                TerritoryId = "MDTCHN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000107630_Kevin",
                                Name = "0000107630 OPEN Level 4 Manager #2",
                                SoldToId = "0000107630",
                                TerritoryId = "MDTIN"
                            },
                            new Customer()
                            {
                                CustomerId = "MDT_0000108143_Kevin",
                                Name = "0000108143 MATTHEW G GOETZ",
                                SoldToId = "0000108143",
                                TerritoryId = "MDTGER"
                            }
                        }
                    });
                    context.SaveChangesAsync();
                }
            }
        }
    }
}
