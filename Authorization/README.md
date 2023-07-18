```
builder.Services.AddSwaggerGen(setup=>

{

    var jwtSecuritySchema = new OpenApiSecurityScheme

    {

        BearerFormat = "JWT",

        Name = "JWT Authentication",

        In = ParameterLocation.Header,

        Type = SecuritySchemeType.Http,

        Scheme = JwtBearerDefaults.AuthenticationScheme,

        Description = "Token'ý buraya yaz",

        Reference = new OpenApiReference

        {

         Id = JwtBearerDefaults.AuthenticationScheme,

         Type = ReferenceType.SecurityScheme

        }

    };

    setup.AddSecurityDefinition(jwtSecuritySchema.Reference.Id, jwtSecuritySchema);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement

    {

        {jwtSecuritySchema,Array.Empty<string>() }

    });

});

```
