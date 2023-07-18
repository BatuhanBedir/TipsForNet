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

--builder.Services.AddSwaggerGen() yöntemi, Swagger servisini projeye eklemek için ASP.NET Core DI (Dependency Injection) 
konteynerine bir hizmet kaydý ekler. Bu hizmet, Swagger/OpenAPI belgelerini oluþturmak için kullanýlýr.

--jwtSecuritySchema adýnda bir OpenApiSecurityScheme nesnesi oluþturulur. Bu nesne, JWT tabanlý kimlik doðrulamasýný 
temsil eder ve Swagger belgelerinde kullanýlacak bir güvenlik þemasý tanýmlar.

BearerFormat özelliði, kullanýlacak JWT biçimini belirtir (JWT olarak ayarlandý).

Name özelliði, güvenlik þemasýnýn adýný belirtir (JWT Authentication olarak ayarlandý).

In özelliði, güvenlik þemasýnýn JWT'nin hangi bölümünde bulunacaðýný belirtir (header olarak ayarlandý).

Type özelliði, güvenlik þemasýnýn HTTP tabanlý olduðunu belirtir (SecuritySchemeType.Http olarak ayarlandý).

Scheme özelliði, güvenlik þemasýnýn JWT kimlik doðrulama þemasýný belirtir (JwtBearerDefaults.AuthenticationScheme olarak ayarlandý).

Description özelliði, Swagger belgelerinde bu güvenlik þemasý için açýklama saðlar (Token'ý buraya yaz olarak ayarlandý).

--jwtSecuritySchema'nýn bir referansýný içeren bir OpenApiReference nesnesi oluþturulur. Bu, JWT güvenlik þemasýnýn Swagger 
belgelerinde referans olarak kullanýlmasýný saðlar.

Id özelliði, güvenlik þemasýnýn benzersiz bir kimlik belirleyicisini belirtir (JwtBearerDefaults.AuthenticationScheme ile ayný 
deðere ayarlandý).
Type özelliði, referansýn bir güvenlik þemasý referansý olduðunu belirtir.

--setup.AddSecurityDefinition() yöntemiyle, oluþturulan JWT güvenlik þemasý tanýmý Swagger/OpenAPI belgelerine eklenir. 
Bu, Swagger UI'da güvenlik þemasýný göstermek için kullanýlýr. jwtSecuritySchema.Reference.Id deðeri ile tanýmlanan referans 
kimliði, güvenlik þemasýný tanýmlayan nesnenin kimlik bilgisini temsil eder.

-setup.AddSecurityRequirement() yöntemiyle, güvenlik gereksinimlerini tanýmlayan bir OpenApiSecurityRequirement nesnesi oluþturulur. Bu, Swagger belgelerindeki güvenlik gereksinimlerini belirtir.

{jwtSecuritySchema, Array.Empty<string>()} ifadesiyle, JWT güvenlik þemasýnýn kullanýlmasýnýn zorunlu olduðu belirtilir. Bu ifade, JWT için herhangi bir yetki kuralý gerektirmediðini belirtir (boþ bir dizi ile temsil edilir).

***Swagger belgelerinde JWT tabanlý kimlik doðrulama þemasýnýn tanýmlanmasýný ve Swagger UI'da bu güvenlik þemasýný kullanýcýya 
göstermeyi saðlar. Bu sayede API'nin kimlik doðrulama gereksinimleri ve kullanýmý belgelerde açýk bir þekilde görüntülenebilir.

```
